namespace Billing.Domain.Enums
{
    public enum InvoiceStatus
    {
        DRAFT,
        ISSUED,
        PARTIALLY_PAID,
        PAID,
        OVERDUE,
        VOID
    }
}
