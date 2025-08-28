using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly PropertyDbContext _context;

        public OwnerRepository(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public async Task<Owner?> GetByIdAsync(OwnerId ownerId)
        {
            return await _context.Owners.FindAsync(ownerId);
        }
    }
}
