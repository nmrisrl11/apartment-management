using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentIsCurrentlyUnavailableError(string message) : Error(message)
    {
    }
}
