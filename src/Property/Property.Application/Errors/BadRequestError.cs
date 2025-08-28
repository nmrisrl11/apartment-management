using FluentResults;

namespace Property.Application.Errors
{
    public class BadRequestError(string message) : Error(message)
    {

    }
}
