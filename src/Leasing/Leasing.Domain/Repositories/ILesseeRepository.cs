using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ILesseeRepository
    {
        Task AddAsync(Lessee lessee);
        Task<Lessee?> GetByIdAsync(LesseeId id);
    }
}
