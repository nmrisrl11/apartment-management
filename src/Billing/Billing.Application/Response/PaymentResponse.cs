using Billing.Domain.Enums;
using Billing.Domain.ValueObjects;

namespace Billing.Application.Response
{
    public class PaymentResponse
    {
        public Guid Id { get; private set; }
        public Guid InvoiceId { get; private set; }
        public decimal Amount { get; private set; }
        public DateTime ProcessedDate { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }
        public string TransactionReference { get; private set; } = string.Empty!;
        public DateTime DateCreated { get; private set; }
        public string Currency { get; set; } = string.Empty;
    }
}
