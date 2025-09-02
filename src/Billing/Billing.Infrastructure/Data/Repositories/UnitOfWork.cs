using Billing.Domain.Repositories;

namespace Billing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillingDbContext _context;
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly ITenantRepository _tenantRepository;
        private readonly ILeasingAgreementRepository _leasingAgreementRepository;
        private readonly IPaymentRepository _paymentRepository;

        public UnitOfWork(
            BillingDbContext context,
            IInvoiceRepository invoiceRepository,
            ITenantRepository tenantRepository,
            ILeasingAgreementRepository leasingAgreementRepository,
            IPaymentRepository paymentRepository)
        {
            _context = context;
            _invoiceRepository = invoiceRepository;
            _tenantRepository = tenantRepository;
            _leasingAgreementRepository = leasingAgreementRepository;
            _paymentRepository = paymentRepository;
        }

        public IInvoiceRepository Invoices => _invoiceRepository;
        public ITenantRepository Tenants => _tenantRepository;
        public ILeasingAgreementRepository LeasingAgreements => _leasingAgreementRepository;
        public IPaymentRepository Payments => _paymentRepository;
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
