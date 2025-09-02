using FluentResults;

namespace Billing.Application.Errors
{
    public class InvoiceIsEmptyError(string message) : Error(message)
    {
    }
}
