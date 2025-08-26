using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly LeasingDbContext _context;

        public TenantRepository(LeasingDbContext context)
        {
            _context = context;
        }
        public async Task<Tenant?> GetByIdAsync(TenantId id)
        {
            return await _context.Tenants.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
