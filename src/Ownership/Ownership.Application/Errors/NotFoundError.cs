using FluentResults;

namespace Ownership.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {

    }
}
