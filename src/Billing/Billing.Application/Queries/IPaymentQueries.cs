using Billing.Application.Response;

namespace Billing.Application.Queries
{
    public interface IPaymentQueries
    {
        Task<PaymentResponse?> GetByIdAsync(Guid id);
        Task<List<PaymentResponse>> GetAllAsync();
    }
}
