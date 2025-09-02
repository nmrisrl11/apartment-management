namespace Billing.Domain.Exceptions
{
    public class InvoiceIsEmptyException(string message) : DomainException(message)
    {
    }
}
