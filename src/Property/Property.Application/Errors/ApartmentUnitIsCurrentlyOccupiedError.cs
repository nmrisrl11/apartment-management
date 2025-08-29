using FluentResults;

namespace Property.Application.Errors
{
    public class ApartmentUnitIsCurrentlyOccupiedError(string message) : Error(message)
    {
    }
}
