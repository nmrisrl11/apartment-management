using Billing.Domain.Repositories;

namespace Billing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillingDbContext _context;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly ILeasingAgreementRepository _leasingAgreementRepository;

        public UnitOfWork(
            BillingDbContext context,
            IInvoiceRepository invoiceRepository,
            ITenantRepository tenantRepository,
            ILeasingAgreementRepository leasingAgreementRepository)
        {
            _context = context;
            _invoiceRepository = invoiceRepository;
            _tenantRepository = tenantRepository;
            _leasingAgreementRepository = leasingAgreementRepository;
        }

        public IInvoiceRepository Invoices => _invoiceRepository;
        public ITenantRepository Tenants => _tenantRepository;
        public ILeasingAgreementRepository LeasingAgreements => _leasingAgreementRepository;
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
