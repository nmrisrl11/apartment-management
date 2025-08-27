using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class LesseeRepository : ILesseeRepository
    {
        private readonly LeasingDbContext _context;

        public LesseeRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Lessee lessee)
        {
            await _context.Lessees.AddAsync(lessee);
        }

        public async Task<Lessee?> GetByIdAsync(LesseeId id)
        {
            return await _context.Lessees.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
