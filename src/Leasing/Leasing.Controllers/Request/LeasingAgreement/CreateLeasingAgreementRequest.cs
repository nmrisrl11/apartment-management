namespace Leasing.Controllers.Request.LeasingAgreement
{
    public class CreateLeasingAgreementRequest
    {
        public Guid LesseeId { get; set; }
        public Guid LessorId { get; set; }
        public Guid ApartmentId { get; set; }
    }
}