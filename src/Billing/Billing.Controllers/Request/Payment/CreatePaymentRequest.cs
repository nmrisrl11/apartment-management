namespace Billing.Controllers.Request.Invoice
{
    public class CreatePaymentRequest
    {
        public Guid InvoiceId { get; set; }
        public string Method { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public string Currency { get; set; } = "PHP";
        public string TransactionReference { get; set; } = string.Empty;
    }
}
