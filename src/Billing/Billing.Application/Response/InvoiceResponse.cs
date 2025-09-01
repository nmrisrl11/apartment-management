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
        public DateRange ServicePeriod { get; private set; } = null!;
        public Money AmountPaid { get; private set; } = new(0, "PHP");
    }
}
