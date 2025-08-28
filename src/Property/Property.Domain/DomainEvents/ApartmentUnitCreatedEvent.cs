using ApartmentManagement.SharedKernel;
using Property.Domain.Entities;

namespace Property.Domain.DomainEvents
{
    public record ApartmentUnitCreatedEvent(ApartmentUnit ApartmentUnit) : IDomainEvent;
}
