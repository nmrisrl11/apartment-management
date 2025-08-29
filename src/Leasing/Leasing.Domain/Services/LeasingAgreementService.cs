using Leasing.Domain.Entities;

namespace Leasing.Domain.Services
{
    public class LeasingAgreementService
    {
        public (LeasingAgreement, LeasingRecord) CreateLeasingAgreement(
            Lessee lessee,
            Lessor lessor,
            Apartment apartment)
        {
            var DateLeased = DateTime.UtcNow;
            var DateRenewal = DateLeased.AddDays(30);

            apartment.MarkAsLeased();

            // Create Leasing Record
            var newLeasingRecord = LeasingRecord.Create(
                lessee.Id,
                lessor.Id,
                apartment.Id,
                DateLeased,
                DateRenewal);

            // Create Leasing Agreement
            var newLeasingAgreement = LeasingAgreement.Create(
                lessee.Id,
                lessor.Id,
                apartment.Id,
                DateLeased,
                DateRenewal);

            return (newLeasingAgreement, newLeasingRecord);
        }

        public void RenewLeasingAgreement(LeasingAgreement leasingAgreement, LeasingRecord leasingRecord)
        {
            leasingAgreement.Renew();
            leasingRecord.AdjustDateRenewal();
        }

        public void TerminateLeasingAgreement(
            LeasingAgreement leasingAgreement,
            LeasingRecord leasingRecord,
            Apartment apartment)
        {
            leasingAgreement.Terminate();
            leasingRecord.MarkAsEnded();
            apartment.MarkAsAvailable();
        }
    }
}
