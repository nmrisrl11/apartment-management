using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ITenantRepository
    {
        Task<Tenant?> GetByIdAsync(TenantId id);
    }
}
