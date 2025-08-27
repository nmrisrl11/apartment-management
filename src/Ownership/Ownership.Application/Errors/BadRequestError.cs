using FluentResults;

namespace Ownership.Application.Errors
{
    public class BadRequestError(string message) : Error(message)
    {

    }
}
