using Billing.Application.Response;

namespace Billing.Application.Commands
{
    public interface ITenantCommands
    {
        Task<TenantResponse> AddAsync(
            Guid id,
            string name,
            CancellationToken cancellationToken);
    }
}
