namespace Property.Domain.Exceptions
{
    public class ApartmentUnitAlreadyLeasedException(string message) : DomainException(message)
    {
    }
}
