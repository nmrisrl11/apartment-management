namespace Leasing.Domain.Exceptions
{
    public class ApartmentAlreadyUnderMaintenanceException(string message) : DomainException(message)
    {
    }
}
