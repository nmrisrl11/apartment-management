using FluentResults;

namespace Billing.Application.Errors
{
    public class CannotMarkAsFailedError(string message) : Error(message)
    {
    }
}
