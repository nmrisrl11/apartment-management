namespace Property.Domain.Exceptions
{
    public class ApartmentUnitIsNotUnderMaintenanceException(string message) : DomainException(message)
    {
    }
}
