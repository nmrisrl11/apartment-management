using Billing.Application.Response;

namespace Billing.Application.Queries
{
    public interface IInvoiceQueries
    {
        Task<InvoiceResponse?> GetByIdAsync(Guid id);
        Task<List<InvoiceResponse>> GetAllAsync();
    }
}
