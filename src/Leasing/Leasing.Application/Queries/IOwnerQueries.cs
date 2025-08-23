using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<OwnerResponse?> GetByIdAsync(Guid id);
        Task<List<OwnerResponse>> GetAllAsync();
    }
}
