using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task AddAsync(Owner owner);
        void DeleteAsync(Owner owner);
        Task<Owner?> GetByIdAsync(OwnerId ownerId);
    }
}
