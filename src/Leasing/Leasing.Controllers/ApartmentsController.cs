using FluentResults;
using Leasing.Application.Commands;
using Leasing.Application.Errors;
using Leasing.Application.Queries;
using Leasing.Application.Response;
using Leasing.Controllers.Request.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace Leasing.Controllers
{
    [Route("api/apartments")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentCommands _commands;
        private readonly IApartmentQueries _queries;

        public ApartmentsController(IApartmentCommands commands, IApartmentQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetApartmentById")]
        public async Task<ActionResult<ApartmentResponse>> GetApartmentById(Guid id)
        {
            ApartmentResponse? apartment = await _queries.GetByIdAsync(id);

            if(apartment is null)
                return NotFound();

            return Ok(apartment);
        }

        [HttpGet()]
        public async Task<ActionResult<List<ApartmentResponse>>> GetAllApartments()
        {
            List<ApartmentResponse> apartments = await _queries.GetAllAsync();

            if(apartments is null || apartments.Count == 0)
                return NotFound();

            return Ok(apartments);
        }

        [HttpPost()]
        public async Task<ActionResult<ApartmentResponse>> CreateApartment(CreateApartmentRequest request)
        {
            ApartmentResponse apartmentToCreate = await _commands.AddAsync(request.OwnerId, request.BuildingNumber, request.ApartmentNumber, HttpContext.RequestAborted);

            return CreatedAtRoute(nameof(GetApartmentById), new { apartmentToCreate.Id }, apartmentToCreate);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApartment(Guid id)
        {
            Result result = await _commands.DeleteAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if(result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApartment(Guid id, UpdateApartmentRequest request)
        {
            Result result = await _commands.UpdateAsync(id, request.BuildingNumber, request.ApartmentNumber, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
