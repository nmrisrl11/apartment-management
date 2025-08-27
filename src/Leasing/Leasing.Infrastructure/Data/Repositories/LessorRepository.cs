using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class LessorRepository : ILessorRepository
    {
        private readonly LeasingDbContext _context;

        public LessorRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lessor lessor)
        {
            await _context.Lessors.AddAsync(lessor);
        }

        public async Task<Lessor?> GetByIdAsync(LessorId lessorId)
        {
            return await _context.Lessors.FindAsync(lessorId);
        }
    }
}
