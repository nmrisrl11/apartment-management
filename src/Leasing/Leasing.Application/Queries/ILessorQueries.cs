using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ILessorQueries
    {
        Task<LessorResponse?> GetByIdAsync(Guid id);
        Task<List<LessorResponse>> GetAllAsync();
    }
}
