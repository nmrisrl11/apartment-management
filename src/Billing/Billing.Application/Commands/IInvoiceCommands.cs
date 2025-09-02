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
            DateTime ServicePeriodStartDate,
            DateTime ServicePeriodEndDate,
            DateTime DateDue,
            CancellationToken cancellationToken);
        Task<Result> DeleteAsync(
            Guid id,
            CancellationToken cancellationToken);
        Task<Result> AddInvoiceLineItemAsync(
            Guid invoiceId,
            string description,
            decimal quantity,
            decimal unitPrice,
            string currency,
            CancellationToken cancellationToken);
        Task<Result> IssueInvoiceAsync(
            Guid invoiceId,
            CancellationToken cancellationToken);
    }
}
