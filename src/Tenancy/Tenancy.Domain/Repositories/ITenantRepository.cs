using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task AddAsync(Tenant tenant);
        void DeleteAsync(Tenant tenant);
        Task<Tenant?> GetByIdAsync(TenantId id);
    }
}
