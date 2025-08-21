using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingAgreement
    {
        public LeasingAgreementId Id { get; private set; }
        public TenantId TenantId { get; private set; }
        public Tenant Tenant { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; }
        public Apartment Apartment { get; private set; } = null!;
        public  AgreementStatus Status { get; private set; }
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }
    }
}
