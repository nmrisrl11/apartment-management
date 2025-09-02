using Billing.Domain.Enums;
using Billing.Domain.Exceptions;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities
{
    public class Payment
    {
        public PaymentId Id { get; private set; } = null!;
        public InvoiceId InvoiceId { get; private set; } = null!;
        public Money Amount { get; private set; } = null!;
        public DateTime ProcessedDate { get; private set; }
        public PaymentMethod Method { get; private set; }
        public PaymentStatus Status { get; private set; }
        public string TransactionReference { get; private set; } = string.Empty!;
        public DateTime DateCreated { get; private set; }

        private Payment() { }

        public static Payment Create(
            Invoice invoice,
            Money amount,
            PaymentMethod method,
            string transactionReference)
        {            
            if (invoice is null)
                throw new InvoiceIsEmptyException("Invoice is empty.");

            if (amount.Amount <= 0)
                throw new InvalidPaymentException("Payment amount must be a positive value.");

            if (amount.Amount > invoice.AmountDue.Amount)
                throw new InvalidPaymentException("Payment amount cannot be greater than the amount due on the invoice.");

            var payment = new Payment
            {
                Id = new PaymentId(Guid.NewGuid()),
                InvoiceId = invoice.Id,
                Amount = amount,
                Method = method,
                TransactionReference = transactionReference,
                Status = PaymentStatus.PENDING,
                DateCreated = DateTime.UtcNow
            };

            return payment;
        }

        public void MarkAsSucceeded(DateTime processedDate)
        {
            if (Status != PaymentStatus.PENDING)
                throw new CannotMarkAsSucceededException("Only a pending payment can be marked as succeeded.");

            Status = PaymentStatus.SUCCEEDED;
            ProcessedDate = processedDate;
        }

        public void MarkAsFailed()
        {
            if (Status != PaymentStatus.PENDING)
                throw new CannotMarkAsFailedException("Only a pending payment can be marked as failed.");

            Status = PaymentStatus.FAILED;
            ProcessedDate = DateTime.UtcNow;
        }
    }
}
