using FluentResults;

namespace Billing.Application.Errors
{
    public class CannotIssueNonDraftInvoiceError(string message) : Error(message)
    {
    }
}
