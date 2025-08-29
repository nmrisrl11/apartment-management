using ApartmentManagement.SharedKernel;
using Property.Domain.Entities;

namespace Property.Domain.DomainEvents
{
    public record ApartmentUnitStartedUnderMaintenanceEvent(ApartmentUnit ApartmentUnit) : IDomainEvent;
}
