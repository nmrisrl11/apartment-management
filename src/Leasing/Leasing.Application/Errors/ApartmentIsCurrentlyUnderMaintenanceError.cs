using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentIsCurrentlyUnderMaintenanceError(string message) : Error(message)
    {
    }
}
