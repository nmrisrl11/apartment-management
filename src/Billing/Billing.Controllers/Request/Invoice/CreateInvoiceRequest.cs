namespace Billing.Controllers.Request.Invoice
{
    public class CreateInvoiceRequest
    {
        public Guid TenantId { get; set; }
        public Guid LeasingAgreementId { get; set; }
        public DateTime ServicePeriodStartDate { get; set; }
        public DateTime ServicePeriodEndDate { get; set; }
        public DateTime DateDue { get; set; }
    }
}