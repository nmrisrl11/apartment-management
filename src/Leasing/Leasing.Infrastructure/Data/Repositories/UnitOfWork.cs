using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(LeasingDbContext context,
            IApartmentRepository apartmentRepository,
            IOwnerRepository ownerRepository)
        {
            _context = context;
            _apartmentRepository = apartmentRepository;
            _ownerRepository = ownerRepository;
        }

        public IApartmentRepository Apartments => _apartmentRepository;

        public IOwnerRepository Owners => _ownerRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
