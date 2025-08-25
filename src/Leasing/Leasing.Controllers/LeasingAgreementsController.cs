using Leasing.Application.Commands;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Controllers.Request.LeasingAgreement;
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
        public async Task<ActionResult<LeasingAgreementResponse>> CreateLeasingAgreement([FromBody] CreateLeasingAgreementRequest request)
        {
            LeasingAgreementResponse leasingAgreementToCreate = await _commands.AddAsync(
                request.TenantName,
                request.TenantEmail,
                request.TenantContactNumber,
                request.OwnerId,
                request.ApartmentId,
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(30),
                HttpContext.RequestAborted);

            return Ok(leasingAgreementToCreate);
        }
    }
}
