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
            var DateCommenced = DateTime.UtcNow;
            var DateExpiry = DateCommenced.AddYears(1);

            apartment.MarkAsLeased();

            // Create Leasing Record
            var newLeasingRecord = LeasingRecord.Create(
                lessee.Id,
                lessor.Id,
                apartment.Id,
                DateCommenced,
                DateExpiry);

            // Create Leasing Agreement
            var newLeasingAgreement = LeasingAgreement.Create(
                lessee.Id,
                lessor.Id,
                apartment.Id,
                DateCommenced,
                DateExpiry);

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
