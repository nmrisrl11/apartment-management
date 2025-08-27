using ApartmentManagement.SharedKernel.Entities;
using Tenancy.Domain.DomainEvents;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Domain.Entities
{
    public class Tenant : Entity
    {
        public TenantId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string ContactNumber { get; private set; } = null!;        

        private Tenant() { }

        private Tenant(TenantId tenantId, string name, string email, string contactNumber)
        {
            Id = tenantId;
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
        }

        public static Tenant Create(string name, string email, string contactNumber)
        {
            var newTenant = new Tenant(new TenantId(Guid.NewGuid()), name, email, contactNumber);

            newTenant.RaiseDomainEvent(new TenantCreatedEvent(newTenant));

            return newTenant;
        }

        public void Update(string name, string email, string contactNumber)
        {
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
        }
    }
}
