using FluentResults;

namespace Billing.Application.Errors
{
    public class InvoiceAlreadyPaidError(string message) : Error(message)
    {
    }
}
