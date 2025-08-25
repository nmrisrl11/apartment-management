using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly ILeasingAgreementRepository _leasingAgreementRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;

        public UnitOfWork(LeasingDbContext context,
            ILeasingAgreementRepository leasingAgreementRepository,
            IApartmentRepository apartmentRepository,
            IOwnerRepository ownerRepository)
        {
            _context = context;
            _leasingAgreementRepository = leasingAgreementRepository;
            _apartmentRepository = apartmentRepository;
            _ownerRepository = ownerRepository;
        }

        public ILeasingAgreementRepository LeasingAgreements => _leasingAgreementRepository;

        public IApartmentRepository Apartments => _apartmentRepository;

        public IOwnerRepository Owners => _ownerRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
