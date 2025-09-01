using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;

namespace Billing.Infrastructure.Data.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly BillingDbContext _context;

        public InvoiceRepository(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
        }

        public void DeleteAsync(Invoice invoice)
        {
            _context.Invoices.Remove(invoice);
        }

        public async Task<Invoice?> GetByIdAsync(InvoiceId invoiceId)
        {
            return await _context.Invoices.FindAsync(invoiceId);
        }
    }
}
