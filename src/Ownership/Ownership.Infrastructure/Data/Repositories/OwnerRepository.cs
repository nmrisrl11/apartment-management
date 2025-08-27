using Ownership.Domain.Entities;
using Ownership.Domain.Repositories;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly OwnershipDbContext _context;

        public OwnerRepository(OwnershipDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
        }

        public void DeleteAsync(Owner owner)
        {
            _context.Owners.Remove(owner);
        }

        public async Task<Owner?> GetByIdAsync(OwnerId ownerId)
        {
            return await _context.Owners.FindAsync(ownerId);
        }
    }
}
