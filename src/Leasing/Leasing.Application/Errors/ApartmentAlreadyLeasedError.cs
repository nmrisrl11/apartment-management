using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentAlreadyLeasedError(string message) : Error(message)
    {
    }
}
