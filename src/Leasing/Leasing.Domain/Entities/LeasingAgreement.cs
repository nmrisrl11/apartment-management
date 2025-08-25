using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingAgreement
    {
        public LeasingAgreementId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public Tenant Tenant { get; private set; } = null!;
        public OwnerId OwnerId { get; private set; } = null!;
        public Owner Owner { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; } = null!;
        public Apartment Apartment { get; private set; } = null!;
        public  AgreementStatus Status { get; private set; }
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }

        protected LeasingAgreement() { }

        // Private constructor for internal use by the static factory method
        private LeasingAgreement(
            LeasingAgreementId id,
            Tenant tenant,
            OwnerId ownerId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            Id = id;
            TenantId = tenant.Id; // Set the TenantId from the new Tenant object
            Tenant = tenant;
            OwnerId = ownerId;
            ApartmentId = apartmentId;
            Status = AgreementStatus.NEW;
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
        }

        public static LeasingAgreement Create(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            OwnerId ownerId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            // First, create the new Tenant entity using its own factory method
            var newTenant = Tenant.Create(
                name: tenantName,
                email: tenantEmail,
                contactNumber: tenantContactNumber);

            // Now, create the LeasingAgreement using the newly created Tenant
            return new LeasingAgreement(
                id: new LeasingAgreementId(Guid.NewGuid()),
                tenant: newTenant,
                ownerId: ownerId,
                apartmentId: apartmentId,
                dateLeased: dateLeased,
                dateRenewal: dateRenewal);
        }
    }
}
