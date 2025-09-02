namespace Billing.Domain.Exceptions
{
    public class CannotMarkAsSucceededException(string message) : DomainException(message)
    {
    }
}
