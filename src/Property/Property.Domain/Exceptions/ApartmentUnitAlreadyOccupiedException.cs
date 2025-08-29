namespace Property.Domain.Exceptions
{
    public class ApartmentUnitAlreadyOccupiedException(string message) : DomainException(message)
    {
    }
}
