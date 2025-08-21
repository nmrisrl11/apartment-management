using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly IApartmentRepository _apartmentRepository;

        public UnitOfWork(LeasingDbContext context,
            IApartmentRepository apartmentRepository)
        {
            _context = context;
            _apartmentRepository = apartmentRepository;
        }

        public IApartmentRepository Apartments => _apartmentRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
