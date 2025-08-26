using Leasing.Domain.Entities;

namespace Leasing.Domain.Services
{
    public class LeasingAgreementService
    {
        public (LeasingAgreement, LeasingRecord) CreateLeasingAgreement(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            Owner owner,
            Apartment apartment)
        {
            var DateLeased = DateTime.UtcNow;
            var DateRenewal = DateLeased.AddDays(30);

            // Create Tenant
            var newTenant = Tenant.Create(
                name: tenantName,
                email: tenantEmail,
                contactNumber: tenantContactNumber);

            apartment.MarkAsOccupied();

            // Create Leasing Record
            var newLeasingRecord = LeasingRecord.Create(
                newTenant.Id,
                owner.Id,
                apartment.Id,
                DateLeased,
                DateRenewal);

            // Create Leasing Agreement
            var newLeasingAgreement = LeasingAgreement.Create(
                newTenant,
                owner.Id,
                apartment.Id,
                DateLeased,
                DateRenewal);

            return (newLeasingAgreement, newLeasingRecord);
        }

        public void RenewLeasingAgreement(LeasingAgreement leasingAgreement, LeasingRecord leasingRecord)
        {
            leasingAgreement.Renew();
            leasingAgreement.DateRenewal.AddDays(30);
            leasingRecord.DateRenewal.AddDays(30);
        }
    }
}
