namespace Property.Domain.Exceptions
{
    public class ApartmentUnitIsCurrentlyUnderRenovationException(string message) : DomainException(message)
    {
    }
}
