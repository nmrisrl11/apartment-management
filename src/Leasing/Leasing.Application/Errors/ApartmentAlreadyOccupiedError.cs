using FluentResults;

namespace Leasing.Application.Errors
{
    public class ApartmentAlreadyOccupiedError(string message) : Error(message)
    {
    }
}
