using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities
{
    public class InvoiceLineItem
    {
        public InvoiceLineItemId Id { get; private set; } = null!;
        public InvoiceId InvoiceId { get; private set; } = null!;
        public Invoice Invoice { get; private set; } = null!;
        public string Description { get; private set; } = string.Empty;
        public decimal Quantity { get; private set; }
        public Money UnitPrice { get; private set; } = null!;
        public Money TotalPrice => UnitPrice * Quantity;

        private InvoiceLineItem() { }

        internal InvoiceLineItem(InvoiceId invoiceId, string description, decimal quantity, Money unitPrice)
        {
            Id = new InvoiceLineItemId(Guid.NewGuid());
            InvoiceId = invoiceId;
            Description = description;
            Quantity = quantity;
            UnitPrice = unitPrice;
        }
    }
}
