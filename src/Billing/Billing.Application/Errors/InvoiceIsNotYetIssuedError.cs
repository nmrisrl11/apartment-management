using FluentResults;

namespace Billing.Application.Errors
{
    public class InvoiceIsNotYetIssuedError(string message) : Error(message)
    {
    }
}
