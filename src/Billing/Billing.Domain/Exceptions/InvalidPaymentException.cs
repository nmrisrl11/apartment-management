namespace Billing.Domain.Exceptions
{
    public class InvalidPaymentException(string message) : DomainException(message)
    {
    }
}
