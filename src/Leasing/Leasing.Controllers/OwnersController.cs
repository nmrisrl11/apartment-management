using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Controllers.Request.Owner;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerCommands _commands;
        private readonly IOwnerQueries _queries;

        public OwnersController(IOwnerCommands commands, IOwnerQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetOwnerById")]
        public async Task<ActionResult<OwnerResponse>> GetOwnerById(Guid id)
        {
            OwnerResponse? owner = await _queries.GetByIdAsync(id);

            if (owner is null)
                return NotFound();

            return Ok(owner);
        }

        [HttpGet()]
        public async Task<ActionResult<List<OwnerResponse>>> GetAllOwners()
        {
            List<OwnerResponse> owners = await _queries.GetAllAsync();

            if (owners is null || owners.Count == 0)
                return NotFound();

            return Ok(owners);
        }

        [HttpPost]
        public async Task<ActionResult<OwnerResponse>> CreateOwner(CreateOwnerRequest request)
        {
            OwnerResponse ownerToCreate = await _commands.AddAsync(request.Name, HttpContext.RequestAborted);

            return CreatedAtRoute(nameof(GetOwnerById), new { ownerToCreate.Id }, ownerToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOwner(Guid id)
        {
            Result result = await _commands.DeleteAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if (result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOwner(Guid id, UpdateOwnerRequest request)
        {
            Result result = await _commands.UpdateAsync(id, request.Name, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
