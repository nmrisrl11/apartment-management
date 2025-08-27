using ApartmentManagement.SharedKernel;
using Ownership.Domain.Entities;

namespace Ownership.Domain.DomainEvents
{
    public record OwnerCreatedEvent(Owner Owner) : IDomainEvent;
}
