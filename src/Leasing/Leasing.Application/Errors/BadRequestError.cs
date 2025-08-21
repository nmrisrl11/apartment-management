using FluentResults;

namespace Leasing.Application.Errors
{
    public class BadRequestError(string message) : Error(message)
    {

    }
}
