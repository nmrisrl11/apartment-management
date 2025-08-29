using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Property.Application.Commands;
using Property.Application.Errors;
using Property.Application.Queries;
using Property.Application.Response;
using Property.Controllers.Request.ApartmentUnit;

namespace Property.Controllers
{
    [Route("api/apartment-units")]
    [ApiController]
    public class ApartmentUnitsController : ControllerBase
    {
        private readonly IApartmentUnitCommands _commands;
        private readonly IApartmentUnitQueries _queries;

        public ApartmentUnitsController(IApartmentUnitCommands commands, IApartmentUnitQueries queries)
        {
            _commands = commands;
            _queries = queries;
        }

        [HttpGet("{id}", Name = "GetApartmentUnitById")]
        public async Task<ActionResult<ApartmentUnitResponse>> GetApartmentUnitById(Guid id)
        {
            ApartmentUnitResponse? apartmentUnit = await _queries.GetByIdAsync(id);

            if (apartmentUnit is null)
                return NotFound();

            return Ok(apartmentUnit);
        }

        [HttpGet()]
        public async Task<ActionResult<List<ApartmentUnitResponse>>> GetAllApartmentUnits()
        {
            List<ApartmentUnitResponse> apartmentUnits = await _queries.GetAllAsync();

            if (apartmentUnits is null || apartmentUnits.Count == 0)
                return NotFound();

            return Ok(apartmentUnits);
        }

        [HttpPost]
        public async Task<ActionResult<ApartmentUnitResponse>> CreateApartmentUnit(CreateApartmentUnitRequest request)
        {
            Result<ApartmentUnitResponse> result = await _commands.AddAsync(
                request.OwnerId,
                request.BuildingNumber,
                request.ApartmentNumber,
                HttpContext.RequestAborted);

            if(result.IsFailed)
            {
                return NotFound(result.Errors.FirstOrDefault()?.Message);
            }

            ApartmentUnitResponse apartmentUnitToCreate = result.Value;

            return CreatedAtRoute(nameof(GetApartmentUnitById), new { apartmentUnitToCreate.Id }, apartmentUnitToCreate);
        }

        [HttpPost("start-under-maintenance/{id}")]
        public async Task<ActionResult> StartUnderMaintenance(Guid id)
        {
            Result result = await _commands.StartUnderMaintenanceAsync(id, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    ApartmentUnitIsCurrentlyOccupiedError => Conflict(error.Message),
                    ApartmentUnitAlreadyUnderMaintenanceError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpPost("finish-under-maintenance/{id}")]
        public async Task<ActionResult> FinishUnderMaintenance(Guid id)
        {
            Result result = await _commands.FinishUnderMaintenanceAsync(id, HttpContext.RequestAborted);

            if (result.IsFailed)
            {
                var error = result.Errors.First();

                return error switch
                {
                    NotFoundError => NotFound(error.Message),
                    ApartmentUnitIsNotUnderMaintenanceError => Conflict(error.Message),
                    _ => StatusCode(StatusCodes.Status500InternalServerError, error.Message)
                };
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApartmentUnit(Guid id)
        {
            Result result = await _commands.DeleteAsync(id, HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);
            else if (result.HasError<BadRequestError>(out var badRequestError))
                return BadRequest(badRequestError.FirstOrDefault()?.Message);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateApartmentUnit(Guid id, UpdateApartmentUnitRequest request)
        {
            Result result = await _commands.UpdateAsync(
                id,
                request.BuildingNumber,
                request.ApartmentNumber,
                HttpContext.RequestAborted);

            if (result.HasError<NotFoundError>(out var notFoundError))
                return NotFound(notFoundError.FirstOrDefault()?.Message);

            return NoContent();
        }
    }
}
