using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentAlreadyUnderMaintenanceError(string message) : Error(message)
    {
    }
}
