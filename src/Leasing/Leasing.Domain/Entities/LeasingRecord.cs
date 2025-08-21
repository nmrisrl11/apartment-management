using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingRecord
    {
        public LeasingRecordId Id { get; private set; }
        public TenantId TenantId { get; private set; }
        public Tenant Tenant { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; }
        public Apartment Apartment { get; private set; } = null!;
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }

        private LeasingRecord(LeasingRecordId id, TenantId tenantId, ApartmentId apartmentId, DateTime dateLeased, DateTime dateRenewal)
        {
            Id = id;
            TenantId = tenantId;
            ApartmentId = apartmentId;
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
        }

        public static LeasingRecord Create(TenantId tenantId, ApartmentId apartmentId, DateTime dateLeased, DateTime dateRenewal)
        {
            return new LeasingRecord(
                new LeasingRecordId(Guid.NewGuid()),
                tenantId,
                apartmentId,
                dateLeased,
                dateRenewal
            );
        }
    }
}
