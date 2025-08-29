using FluentResults;

namespace Property.Application.Errors
{
    public class ApartmentUnitIsNotUnderMaintenanceError(string message) : Error(message)
    {
    }
}
