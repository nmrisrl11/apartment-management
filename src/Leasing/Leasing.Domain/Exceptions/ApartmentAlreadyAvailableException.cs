namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyAvailableException(string message) : DomainException(message)
    {
    }
}
