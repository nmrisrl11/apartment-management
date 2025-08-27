using ApartmentManagement.SharedKernel;
using Tenancy.Domain.Entities;

namespace Tenancy.Domain.DomainEvents
{
    public record TenantCreatedEvent(Tenant Tenant) : IDomainEvent;
}
