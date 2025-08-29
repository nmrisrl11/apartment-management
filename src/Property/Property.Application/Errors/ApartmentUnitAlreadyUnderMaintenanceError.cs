using FluentResults;

namespace Property.Application.Errors
{
    public class ApartmentUnitAlreadyUnderMaintenanceError(string message) : Error(message)
    {
    }
}
