using FluentResults;

namespace Billing.Application.Errors
{
    public class CannotAddLineItemToIssuedInvoiceError(string message) : Error(message)
    {
    }
}
