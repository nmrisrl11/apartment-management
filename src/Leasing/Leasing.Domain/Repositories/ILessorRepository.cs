using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ILessorRepository
    {
        Task AddAsync(Lessor lessor);
        Task<Lessor?> GetByIdAsync(LessorId lessorId);
    }
}
