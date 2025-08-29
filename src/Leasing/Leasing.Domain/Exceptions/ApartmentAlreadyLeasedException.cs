namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyLeasedException(string message) : DomainException(message)
    {
    }
}
