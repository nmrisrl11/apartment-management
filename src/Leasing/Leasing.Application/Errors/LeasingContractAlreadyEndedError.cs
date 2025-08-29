using FluentResults;

namespace Leasing.Application.Errors
{
    public class LeasingContractAlreadyEndedError(string message) : Error(message)
    {
    }
}
