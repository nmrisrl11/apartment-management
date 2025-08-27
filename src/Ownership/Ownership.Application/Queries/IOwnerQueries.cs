using Ownership.Application.Response;

namespace Ownership.Application.Queries
{
    public interface IOwnerQueries
    {
        Task<OwnerResponse?> GetByIdAsync(Guid id);
        Task<List<OwnerResponse>> GetAllAsync();
    }
}
