using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingRecord
    {
        public LeasingRecordId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public Tenant Tenant { get; private set; } = null!;
        public OwnerId OwnerId { get; private set; } = null!;
        public Owner Owner { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; } = null!;
        public Apartment Apartment { get; private set; } = null!;
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }

        private LeasingRecord(LeasingRecordId id,
            TenantId tenantId,
            OwnerId ownerId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            Id = id;
            TenantId = tenantId;
            OwnerId = ownerId;
            ApartmentId = apartmentId;
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
        }

        public static LeasingRecord Create(
            TenantId tenantId,
            OwnerId ownerId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            return new LeasingRecord(
                new LeasingRecordId(Guid.NewGuid()),
                tenantId,
                ownerId,
                apartmentId,
                dateLeased,
                dateRenewal
            );
        }
    }
}
