namespace Leasing.Domain.Exceptions
{
    public class ApartmentIsCurrentlyUnavailableException(string message) : DomainException(message)
    {
    }
}
