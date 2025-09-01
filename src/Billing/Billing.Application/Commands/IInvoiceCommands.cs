using Billing.Application.Response;
using Billing.Domain.ValueObjects;
using FluentResults;

namespace Billing.Application.Commands
{
    public interface IInvoiceCommands
    {
        Task<Result<InvoiceResponse>> AddAsync(
            Guid tenantId,
            Guid leasingAgreementId,
            CancellationToken cancellationToken);
        Task<Result> DeleteAsync(
            Guid invoiceId,
            CancellationToken cancellationToken);
        Task<Result> AddInvoiceLineItemAsync(
            Guid invoiceId,
            string description,
            decimal quantity,
            Money unitPrice,
            CancellationToken cancellationToken);
        Task<Result> IssueInvoiceAsync(
            Guid invoiceId,
            CancellationToken cancellationToken);
    }
}
