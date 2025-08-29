namespace Property.Domain.Exceptions
{
    public class ApartmentUnitIsCurrentlyOccupiedException(string message) : DomainException(message)
    {
    }
}
