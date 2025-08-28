using FluentResults;

namespace Property.Application.Errors
{
    public class NotFoundError(string message) : Error(message)
    {

    }
}
