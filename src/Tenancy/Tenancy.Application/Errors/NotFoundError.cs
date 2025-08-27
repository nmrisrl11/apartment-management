using FluentResults;

namespace Tenancy.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {

    }
}
