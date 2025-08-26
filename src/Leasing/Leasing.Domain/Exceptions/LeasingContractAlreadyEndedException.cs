namespace Leasing.Domain.Exceptions
{
    public class LeasingContractAlreadyEndedException(string message) : DomainException(message)
    {
    }
}
