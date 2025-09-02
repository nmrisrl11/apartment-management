using Billing.Domain.Enums;
using Billing.Domain.ValueObjects;

namespace Billing.Application.Response
{
    public class InvoiceLineItemResponse
    {
        public Guid Id { get; private set; }
        public string Description { get; set; } = string.Empty;
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
