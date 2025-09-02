using ApartmentManagement.SharedKernel.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities
{
    public class Tenant : Entity
    {
        public TenantId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        public static Tenant Create(Guid id, string name)
        {
           return new Tenant
           {
               Id = new TenantId(id),
               Name = name
           };
        }
    }
}
