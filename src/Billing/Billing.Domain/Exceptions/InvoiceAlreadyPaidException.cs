namespace Billing.Domain.Exceptions
{
    public class InvoiceAlreadyPaidException(string message) : DomainException(message)
    {
    }
}
