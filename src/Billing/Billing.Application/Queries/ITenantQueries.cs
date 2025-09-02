using Billing.Application.Response;

namespace Billing.Application.Queries
{
    public interface ITenantQueries
    {
        Task<TenantResponse?> GetByIdAsync(Guid id);
        Task<List<TenantResponse>> GetAllAsync();
    }
}
