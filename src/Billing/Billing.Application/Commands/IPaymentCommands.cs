using Billing.Application.Response;
using FluentResults;

namespace Billing.Application.Commands
{
    public interface IPaymentCommands
    {
        Task<Result<PaymentResponse>> AddAsync(
            Guid invoiceId,
            decimal amount,
            string currency,
            string method,
            string transactionReference,
            CancellationToken cancellationToken);
        Task<Result> DeleteAsync(
            Guid id,
            CancellationToken cancellationToken);
    }
}
