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
        private readonly ILesseeQueries _lesseeQueries;
        private readonly IApartmentQueries _apartmentQueries;

        public LeasingAgreementsController(
            ILeasingAgreementCommands commands,
            ILeasingAgreementQueries queries,
            ILesseeQueries lesseeQueries,
            IApartmentQueries apartmentQueries)
        {
            _commands = commands;
            _queries = queries;
            _lesseeQueries = lesseeQueries;
            _apartmentQueries = apartmentQueries;
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

        [HttpGet("lessee/history/{id}")]
        public async Task<ActionResult<LesseeResponse>> GetLesseeLeasingHistoryById(Guid id)
        {
            LesseeResponse? leseeLeasingHistory = await _lesseeQueries.GetByIdAsync(id);
                
            if (leseeLeasingHistory is null)
                return NotFound();

            return Ok(leseeLeasingHistory);
        }

        [HttpGet("lessee/history/all")]
        public async Task<ActionResult<List<LesseeResponse>>> GetLesseeAllLeasingHistory()
        {
            List<LesseeResponse> leseeLeasingHistory = await _lesseeQueries.GetAllAsync();

            if (leseeLeasingHistory is null || leseeLeasingHistory.Count == 0)
                return NotFound();

            return Ok(leseeLeasingHistory);
        }

        [HttpGet("apartment/history/{id}")]
        public async Task<ActionResult<ApartmentResponse>> GetApartmentLeasingHistoryById(Guid id)
        {
            ApartmentResponse? apartmentLeasingHistory = await _apartmentQueries.GetByIdAsync(id);

            if (apartmentLeasingHistory is null)
                return NotFound();

            return Ok(apartmentLeasingHistory);
        }

        [HttpGet("apartment/history/all")]
        public async Task<ActionResult<List<ApartmentResponse>>> GetApartmentAllLeasingHistory()
        {
            List<ApartmentResponse> apartmentLeasingHistory = await _apartmentQueries.GetAllAsync();

            if (apartmentLeasingHistory is null || apartmentLeasingHistory.Count == 0)
                return NotFound();

            return Ok(apartmentLeasingHistory);
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

        [HttpPost("terminate")]
        public async Task<ActionResult> TerminateLeasingAgreement([FromBody] TerminateLeasingAgreementRequest request)
        {
            Result result = await _commands.TeminateAsync(
                request.LeasingAgreementId,
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
                    LeasingContractAlreadyEndedError => Conflict(error.Message),
                    ApartmentAlreadyAvailableError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok(result);
        }
    }
}
