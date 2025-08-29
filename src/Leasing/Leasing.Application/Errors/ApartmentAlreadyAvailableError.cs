using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentAlreadyAvailableError(string message) : Error(message)
    {
    }
}
