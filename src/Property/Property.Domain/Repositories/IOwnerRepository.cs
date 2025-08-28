using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IOwnerRepository
    {
        Task AddAsync(Owner owner);
        Task<Owner?> GetByIdAsync(OwnerId ownerId);
    }
}
