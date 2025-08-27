using Tenancy.Application.Response;

namespace Tenancy.Application.Queries
{
    public interface ITenantQueries
    {
        Task<TenantResponse?> GetByIdAsync(Guid id);
        Task<List<TenantResponse>> GetAllAsync();
    }
}
