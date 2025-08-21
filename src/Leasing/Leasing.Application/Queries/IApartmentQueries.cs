using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface IApartmentQueries
    {
        Task<ApartmentResponse?> GetByIdAsync(Guid id);
        Task<List<ApartmentResponse>> GetAllAsync();
    }
}
