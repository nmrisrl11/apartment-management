using Ownership.Domain.Repositories;

namespace Ownership.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly OwnershipDbContext _context;
        private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(
            OwnershipDbContext context,
            IOwnerRepository ownerRepository)
        {
            _context = context;
            _ownerRepository = ownerRepository;
        }

        public IOwnerRepository Owners => _ownerRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
