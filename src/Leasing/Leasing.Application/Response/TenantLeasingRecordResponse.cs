using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Application.Response
{
    public class TenantLeasingRecordResponse
    {
        public Guid Id { get; set; }
        public ApartmentLeasedResponse Apartment { get; private set; } = null!;
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }

    }

    public class ApartmentLeasedResponse
    {
        public Guid Id { get; set; }
        public OwnerId OwnerId { get; set; } = null!;
        public Owner Owner { get; set; } = null!;
        public string BuildingNumber { get; set; } = string.Empty;
        public string ApartmentNumber { get; set; } = string.Empty;
    }
}
