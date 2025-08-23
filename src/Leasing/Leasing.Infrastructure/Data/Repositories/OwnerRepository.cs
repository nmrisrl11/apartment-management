using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly LeasingDbContext _context;

        public OwnerRepository(LeasingDbContext context)
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
