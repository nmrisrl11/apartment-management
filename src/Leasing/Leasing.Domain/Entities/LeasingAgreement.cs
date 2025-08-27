using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingAgreement
    {
        public LeasingAgreementId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public Tenant Tenant { get; private set; } = null!;
        public LessorId LessorId { get; private set; } = null!;
        public Lessor Lessor { get; private set; } = null!;
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
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            Id = id;
            TenantId = tenant.Id;
            Tenant = tenant;
            LessorId = lessorId;
            ApartmentId = apartmentId;
            Status = AgreementStatus.NEW;
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
        }

        public static LeasingAgreement Create(
            Tenant newTenant,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            return new LeasingAgreement(
                id: new LeasingAgreementId(Guid.NewGuid()),
                tenant: newTenant,
                lessorId: lessorId,
                apartmentId: apartmentId,
                dateLeased: dateLeased,
                dateRenewal: dateRenewal);
        }

        public void Renew()
        {
            Status = AgreementStatus.RENEWED;
            DateRenewal = DateRenewal.AddDays(30);
        }
    }
}
