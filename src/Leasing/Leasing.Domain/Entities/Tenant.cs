using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string ContactNumber { get; private set; } = null!;
        public List<LeasingRecord> LeasingHistory { get; set; } = [];

        public static Tenant Create(string name, string email, string contactNumber)
        {
            return new Tenant
            {
                Id = new TenantId(Guid.NewGuid()),
                Name = name,
                Email = email,
                ContactNumber = contactNumber
            };
        }

        public void Update(string name, string email, string contactNumber)
        {
            Name = name;
            Email = email;
            ContactNumber = contactNumber;
        }
    }
}
