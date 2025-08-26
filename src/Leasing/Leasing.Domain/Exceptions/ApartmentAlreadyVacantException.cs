namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyVacantException(string message) : DomainException(message)
    {
    }
}
