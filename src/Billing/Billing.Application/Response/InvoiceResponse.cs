using Billing.Domain.Enums;
using Billing.Domain.ValueObjects;

namespace Billing.Application.Response
{
    public class InvoiceResponse
    {
        public Guid Id { get; private set; }
        public Guid TenantId { get; private set; }
        public Guid LeasingAgreementId { get; private set; }
        public string InvoiceNumber { get; private set; } = string.Empty;
        public InvoiceStatus Status { get; private set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateIssued { get; private set; }
        public DateTime DateDue { get; private set; }

        public DateTime ServicePeriodStartDate { get; private set; }
        public DateTime ServicePeriodEndDate { get; private set; }

        public List<InvoiceLineItemResponse> LineItems { get; set; } = null!;

        public decimal Subtotal { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal AmountDue { get; set; }
        public string Currency { get; set; } = string.Empty;
    }
}
