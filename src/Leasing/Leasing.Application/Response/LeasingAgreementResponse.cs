using Leasing.Domain.Enums;

namespace Leasing.Application.Response
{
    public class LeasingAgreementResponse
    {
        public Guid Id { get; set; }
        public LesseeSummaryResponse Lessee { get; set; } = null!;
        public LessorResponse Lessor { get; set; } = null!;
        public ApartmentSummaryResponse Apartment { get; set; } = null!;
        public AgreementStatus Status { get; set; }
        public DateTime DateLeased { get; set; }
        public DateTime DateRenewal { get; set; }
    }
}
