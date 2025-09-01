namespace Billing.Domain.Exceptions
{
    public class CannotIssueNonDraftInvoiceException(string message) : DomainException(message)
    {
    }
}
