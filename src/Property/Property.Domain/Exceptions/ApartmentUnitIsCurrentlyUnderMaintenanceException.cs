namespace Property.Domain.Exceptions
{
    public class ApartmentUnitIsCurrentlyUnderMaintenanceException(string message) : DomainException(message)
    {
    }
}
