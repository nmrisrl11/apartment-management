namespace Billing.Domain.Exceptions
{
    public class InvoiceIsNotYetIssuedException(string message) : DomainException(message)
    {
    }
}
