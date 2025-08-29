using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentAlreadyUnavailableError(string message) : Error(message)
    {
    }
}
