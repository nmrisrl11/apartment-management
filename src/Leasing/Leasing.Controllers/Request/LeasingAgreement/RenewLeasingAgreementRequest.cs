namespace Leasing.Controllers.Request.LeasingAgreement
{
    public class RenewLeasingAgreementRequest
    {
        public Guid LeasingAgreementId { get; set; }
        public Guid LesseeId { get; set; }
        public Guid LessorId { get; set; }
        public Guid ApartmentId { get; set; }
    }
}
