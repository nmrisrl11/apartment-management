using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Tenancy.Application.Commands;
using Tenancy.Application.Errors;
using Tenancy.Application.Queries;
using Tenancy.Application.Response;
using Tenancy.Controllers.Request.Tenant;

namespace Tenancy.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantCommands _commands;
        private readonly ITenantQueries _queries;

        public TenantsController(ITenantCommands commands, ITenantQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetTenantById")]
        public async Task<ActionResult<TenantResponse>> GetTenantById(Guid id)
        {
            TenantResponse? tenant = await _queries.GetByIdAsync(id);

            if (tenant is null)
                return NotFound();

            return Ok(tenant);
        }

        [HttpGet()]
        public async Task<ActionResult<List<TenantResponse>>> GetAllTenants()
        {
            List<TenantResponse> tenants = await _queries.GetAllAsync();

            if (tenants is null || tenants.Count == 0)
                return NotFound();

            return Ok(tenants);
        }

        [HttpPost]
        public async Task<ActionResult<TenantResponse>> CreateTenant(CreateTenantRequest request)
        {
            TenantResponse tenantToCreate = await _commands.AddAsync(
                request.Name,
                request.Email,
                request.ContactNumber,
                HttpContext.RequestAborted);

            return CreatedAtRoute(nameof(GetTenantById), new { tenantToCreate.Id }, tenantToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTenant(Guid id)
        {
            Result result = await _commands.DeleteAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if (result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTenant(Guid id, UpdateTenantRequest request)
        {
            Result result = await _commands.UpdateAsync(
                id,
                request.Name,
                request.Email,
                request.ContactNumber,
                HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
