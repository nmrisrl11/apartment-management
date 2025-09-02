namespace Billing.Controllers.Request.Invoice
{
    public class AddInvoiceLineItemRequest
    {
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public string Currency { get; set; } = "PHP";
    }
}