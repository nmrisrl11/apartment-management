using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ILesseeQueries
    {
        Task<LesseeResponse?> GetByIdAsync(Guid id);
        Task<List<LesseeResponse>> GetAllAsync();
    }
}
