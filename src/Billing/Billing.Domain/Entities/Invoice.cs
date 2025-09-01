using Billing.Domain.Enums;
using Billing.Domain.Exceptions;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities
{
    public class Invoice
    {
        public InvoiceId Id { get; private set; } = null!;
        public TenantId TenantId { get; private set; } = null!;
        public LeasingAgreementId LeasingAgreementId { get; private set; } = null!;
        public string InvoiceNumber { get; private set; } = string.Empty;        
        public InvoiceStatus Status { get; private set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateIssued { get; private set; }
        public DateTime DateDue { get; private set; }
        public DateRange ServicePeriod { get; private set; } = null!;

        private readonly List<InvoiceLineItem> _lineItems = new();
        public IReadOnlyCollection<InvoiceLineItem> LineItems => _lineItems.AsReadOnly();

        // Financial calculations should use the Money Value Object
        public Money Subtotal => new(_lineItems.Sum(li => li.TotalPrice.Amount), "PHP");
        public Money TotalAmount => Subtotal; // Add taxes/fees here if needed
        public Money AmountPaid { get; private set; } = new(0, "PHP");
        public Money AmountDue => TotalAmount - AmountPaid;

        private Invoice() { }
        
        public static Invoice Create(
            TenantId tenantId,
            LeasingAgreementId leasingAgreementId
            //DateRange period,
            //DateTime dateDue
            )
        {            
            var invoice = new Invoice
            {
                Id = new InvoiceId(Guid.NewGuid()),
                TenantId = tenantId,
                LeasingAgreementId = leasingAgreementId,
                InvoiceNumber = GenerateInvoiceNumber(),
                Status = InvoiceStatus.DRAFT,
                DateCreated = DateTime.UtcNow,
                DateIssued = null,
                //DateDue = dateDue,
                //ServicePeriod = period
            };

            return invoice;
        }

        // --- New Simple Invoice Number Generator ---

        /// <summary>
        /// Generates a human-readable, semi-random invoice number.
        /// Format: INV-YYYYMMDD-XXXXX
        /// Example: INV-20250901-A4T8B
        /// </summary>
        /// <returns>A new invoice number string.</returns>
        private static string GenerateInvoiceNumber()
        {
            // 1. Get the current date part
            string datePart = DateTime.UtcNow.ToString("yyyyMMdd");

            // 2. Generate a short, random alphanumeric string
            // We use a Guid and take a small part of it for simplicity.
            // Taking the first 5 characters of a new Guid is random enough for most cases.
            string randomPart = Guid.NewGuid().ToString("N").ToUpper().Substring(0, 5);

            // 3. Combine the parts
            return $"INV-{datePart}-{randomPart}";
        }

        // Public methods to manipulate the aggregate (business logic)
        public void AddLineItem(
            InvoiceId invoiceId,
            string description,
            decimal quantity,
            Money unitPrice)
        {
            if (Status != InvoiceStatus.DRAFT)
                throw new CannotAddLineItemToIssuedInvoiceException("Cannot add items to an issued invoice.");

            var lineItem = new InvoiceLineItem(invoiceId, description, quantity, unitPrice);
            _lineItems.Add(lineItem);
        }

        public void Issue()
        {
            if (Status != InvoiceStatus.DRAFT || !_lineItems.Any())
                throw new CannotIssueNonDraftInvoiceException("Cannot issue an empty or non-draft invoice.");

            Status = InvoiceStatus.ISSUED;
            DateIssued = DateTime.UtcNow;
        }

        public void ApplyPayment(Money paymentAmount)
        {
            if (paymentAmount.Amount <= 0)
                throw new InvalidPaymentException("Payment amount must be positive.");

            AmountPaid += paymentAmount;

            if (AmountDue.Amount <= 0)
            {
                Status = InvoiceStatus.PAID;
            }
            else
            {
                Status = InvoiceStatus.PARTIALLY_PAID;
            }
        }
    }
}
