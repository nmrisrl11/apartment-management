namespace Property.Domain.Exceptions
{
    public class ApartmentUnitAlreadyUnderMaintenanceException(string message) : DomainException(message)
    {
    }
}
