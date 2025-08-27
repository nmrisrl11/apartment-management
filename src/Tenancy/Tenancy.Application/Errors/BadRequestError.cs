using FluentResults;

namespace Tenancy.Application.Errors
{
    public class BadRequestError(string message) : Error(message)
    {

    }
}
