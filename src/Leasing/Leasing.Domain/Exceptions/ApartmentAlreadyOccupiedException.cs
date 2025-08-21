namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyOccupiedException(string message) : DomainException(message)
    {
    }
}
