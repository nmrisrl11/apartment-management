namespace Leasing.Controllers.Request.LeasingAgreement
{
    public class CreateLeasingAgreementRequest
    {
        public required string TenantName { get; set; } = string.Empty;
        public required string TenantEmail { get; set; } = string.Empty;
        public required string TenantContactNumber { get; set; } = string.Empty;
        public Guid OwnerId { get; set; }
        public Guid ApartmentId { get; set; }
    }
}