using FluentResults;

namespace Billing.Application.Errors
{
    public class BadRequestError(string message) : Error(message)
    {

    }
}
