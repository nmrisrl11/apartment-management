namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyUnavailableException(string message) : DomainException(message)
    {
    }
}
