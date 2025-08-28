using Property.Domain.Repositories;

namespace Property.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PropertyDbContext _context;
        private readonly IApartmentUnitRepository _apartmentUnitRepository;
        private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(
            PropertyDbContext context,
            IApartmentUnitRepository apartmentUnitRepository,
            IOwnerRepository ownerRepository)
        {
            _context = context;
            _apartmentUnitRepository = apartmentUnitRepository;
            _ownerRepository = ownerRepository;
        }

        public IApartmentUnitRepository ApartmentUnits => _apartmentUnitRepository;
        public IOwnerRepository Owners => _ownerRepository;
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
