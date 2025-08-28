using Property.Application.Response;

namespace Property.Application.Queries
{
    public interface IApartmentUnitQueries
    {
        Task<ApartmentUnitResponse?> GetByIdAsync(Guid id);
        Task<List<ApartmentUnitResponse>> GetAllAsync();
    }
}
