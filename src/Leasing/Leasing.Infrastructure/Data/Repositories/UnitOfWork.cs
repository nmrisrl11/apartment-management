using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LeasingDbContext _context;
        private readonly ILeasingAgreementRepository _leasingAgreementRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly IApartmentRepository _apartmentRepository;
        private readonly ILeasingRecordRepository _leasingRecordRepository;
        private readonly ILessorRepository _lessorRepository;

        public UnitOfWork(
            LeasingDbContext context,
            ILeasingAgreementRepository leasingAgreementRepository,
            ITenantRepository tenantRepository,
            IApartmentRepository apartmentRepository,
            ILeasingRecordRepository leasingRecordRepository,
            ILessorRepository lessorRepository)
        {
            _context = context;
            _leasingAgreementRepository = leasingAgreementRepository;
            _tenantRepository = tenantRepository;
            _apartmentRepository = apartmentRepository;
            _leasingRecordRepository = leasingRecordRepository;
            _lessorRepository = lessorRepository;
        }

        public ILeasingAgreementRepository LeasingAgreements => _leasingAgreementRepository;
        public ITenantRepository Tenants => _tenantRepository;
        public IApartmentRepository Apartments => _apartmentRepository;
        public ILeasingRecordRepository LeasingRecords => _leasingRecordRepository;
        public ILessorRepository Lessors => _lessorRepository;
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
