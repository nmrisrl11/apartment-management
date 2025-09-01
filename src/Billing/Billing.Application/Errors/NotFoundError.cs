using FluentResults;

namespace Billing.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {

    }
}
