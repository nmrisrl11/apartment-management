using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task AddAsync(Tenant tenant);
        Task<Tenant?> GetByIdAsync(TenantId id);
    }
}
