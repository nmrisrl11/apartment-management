using Tenancy.Domain.Repositories;

namespace Tenancy.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TenancyDbContext _context;
        private readonly ITenantRepository _tenantRepository;

        public UnitOfWork(
            TenancyDbContext context,
            ITenantRepository tenantRepository)
        {
            _context = context;
            _tenantRepository = tenantRepository;
        }

        public ITenantRepository Tenants => _tenantRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
