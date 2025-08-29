namespace Property.Domain.Exceptions
{
    public class ApartmentUnitAlreadyVacantException(string message) : DomainException(message)
    {
    }
}
