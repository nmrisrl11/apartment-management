using FluentResults;

namespace Billing.Application.Errors
{
    public class InvalidPaymentError(string message) : Error(message)
    {
    }
}
