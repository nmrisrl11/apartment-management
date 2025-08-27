using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ITenantQueries
    {
        Task<TenantResponse?> GetByIdAsync(Guid id);
        Task<List<TenantResponse>> GetAllAsync();
    }
}
