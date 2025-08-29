using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Controllers.Request.LeasingAgreement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controllers
{
    [Route("api/leasing-agreements")]
    [ApiController]
    public class LeasingAgreementsController : ControllerBase
    {
        private readonly ILeasingAgreementCommands _commands;
        private readonly ILeasingAgreementQueries _queries;

        public LeasingAgreementsController(ILeasingAgreementCommands commands, ILeasingAgreementQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetLeasingAgreementById")]
        public async Task<ActionResult<LeasingAgreementResponse>> GetLeasingAgreementById(Guid id)
        {
            LeasingAgreementResponse? leasingAgreement = await _queries.GetByIdAsync(id);

            if(leasingAgreement is null)
                return NotFound();

            return Ok(leasingAgreement);
        }

        [HttpGet()]
        public async Task<ActionResult<List<LeasingAgreementResponse>>> GetAllLeasingAgreements()
        {
            List<LeasingAgreementResponse> leasingAgreements = await _queries.GetAllAsync();

            if (leasingAgreements is null || leasingAgreements.Count == 0)
                return NotFound();

            return Ok(leasingAgreements);
        }

        [HttpPost]
        public async Task<ActionResult> CreateLeasingAgreement([FromBody] CreateLeasingAgreementRequest request)
        {
            Result result = await _commands.AddAsync(
                request.LesseeId,
                request.LessorId,
                request.ApartmentId,
                HttpContext.RequestAborted);
            
            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    ApartmentIsCurrentlyUnavailableError => Conflict(error.Message),
                    ApartmentAlreadyLeasedError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPost("renew")]
        public async Task<ActionResult> RenewLeasingAgreement([FromBody] RenewLeasingAgreementRequest request)
        {
            Result result = await _commands.RenewAsync(
                request.LeasingAgreementId,
                request.LesseeId,
                request.LessorId,
                request.ApartmentId,
                HttpContext.RequestAborted);

            if(result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok(result);
        }
    }
}
