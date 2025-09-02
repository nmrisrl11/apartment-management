using Billing.Application.Response;

namespace Billing.Application.Commands
{
    public interface ILeasingAgreementCommands
    {
        Task<LeasingAgreementResponse> AddAsync(
            Guid id,
            CancellationToken cancellationToken);
    }
}
