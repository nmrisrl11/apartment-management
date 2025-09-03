using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Repositories
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
        void DeleteAsync(Invoice invoice);
        Task<Invoice?> GetByIdAsync(InvoiceId invoiceId);
        Task<Invoice?> GetByIdWithLineItemsAsync(InvoiceId invoiceId);
    }
}
