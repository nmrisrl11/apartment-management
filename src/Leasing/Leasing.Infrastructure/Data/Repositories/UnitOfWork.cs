using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly ILeasingAgreementRepository _leasingAgreementRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly ILeasingRecordRepository _leasingRecordRepository;

        public UnitOfWork(
            LeasingDbContext context,
            ILeasingAgreementRepository leasingAgreementRepository,
            IApartmentRepository apartmentRepository,
            IOwnerRepository ownerRepository,
            ILeasingRecordRepository leasingRecordRepository)
        {
            _context = context;
            _leasingAgreementRepository = leasingAgreementRepository;
            _apartmentRepository = apartmentRepository;
            _ownerRepository = ownerRepository;
            _leasingRecordRepository = leasingRecordRepository;
        }

        public ILeasingAgreementRepository LeasingAgreements => _leasingAgreementRepository;

        public IApartmentRepository Apartments => _apartmentRepository;

        public IOwnerRepository Owners => _ownerRepository;

        public ILeasingRecordRepository LeasingRecords => _leasingRecordRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
