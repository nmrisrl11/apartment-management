using ApartmentManagement.SharedKernel;
using Property.Domain.Entities;

namespace Property.Domain.DomainEvents
{
    public record ApartmentUnitFinishedUnderMaintenanceEvent(ApartmentUnit ApartmentUnit) : IDomainEvent;
}
