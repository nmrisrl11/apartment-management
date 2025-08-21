using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Tenant
    {
        public TenantId Id { get; set; } = null!;
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
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
