namespace Billing.Domain.Exceptions
{
    public class CannotMarkAsFailedException(string message) : DomainException(message)
    {
    }
}
