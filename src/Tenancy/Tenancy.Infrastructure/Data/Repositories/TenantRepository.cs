using Tenancy.Domain.Entities;
using Tenancy.Domain.Repositories;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastructure.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly TenancyDbContext _context;

        public TenantRepository(TenancyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
        }

        public void DeleteAsync(Tenant tenant)
        {
            _context.Tenants.Remove(tenant);
        }

        public async Task<Tenant?> GetByIdAsync(TenantId tenantId)
        {
            return await _context.Tenants.FindAsync(tenantId);
        }
    }
}
