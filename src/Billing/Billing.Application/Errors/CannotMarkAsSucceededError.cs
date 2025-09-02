using FluentResults;

namespace Billing.Application.Errors
{
    public class CannotMarkAsSucceededError(string message) : Error(message)
    {
    }
}
