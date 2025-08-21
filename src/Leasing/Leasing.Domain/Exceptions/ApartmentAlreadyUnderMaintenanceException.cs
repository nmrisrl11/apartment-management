namespace Leasing.Domain.Exceptions
{
    public class ApartmentIsCurrentlyUnderMaintenanceException(string message) : DomainException(message)
    {
    }
}
