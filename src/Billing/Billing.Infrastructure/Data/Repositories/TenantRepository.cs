using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Data.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly BillingDbContext _context;

        public TenantRepository(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Tenant tenant)
        {
            await _context.Tenants.AddAsync(tenant);
        }

        public async Task<Tenant?> GetByIdAsync(TenantId id)
        {
            return await _context.Tenants.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
