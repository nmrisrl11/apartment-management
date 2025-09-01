namespace Billing.Domain.Exceptions
{
    public class CannotAddLineItemToIssuedInvoiceException(string message) : DomainException(message)
    {
    }
}
