using FluentResults;

namespace Leasing.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {

    }
}
