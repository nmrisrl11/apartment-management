using Billing.Domain.Repositories;

namespace Billing.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillingDbContext _context;
        private readonly IInvoiceRepository _invoiceRepository;

        public UnitOfWork(
            BillingDbContext context,
            IInvoiceRepository invoiceRepository)
        {
            _context = context;
            _invoiceRepository = invoiceRepository;
        }

        public IInvoiceRepository Invoices => _invoiceRepository;

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
