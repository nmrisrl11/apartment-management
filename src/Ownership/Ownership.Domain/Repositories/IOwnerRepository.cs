using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task AddAsync(Owner owner);
        void DeleteAsync(Owner owner);
        Task<Owner?> GetByIdAsync(OwnerId ownerId);
    }
}
