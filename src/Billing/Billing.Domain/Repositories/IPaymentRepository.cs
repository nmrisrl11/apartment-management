using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task AddAsync(Payment payment);
        void DeleteAsync(Payment payment);
        Task<Payment?> GetByIdAsync(PaymentId id);
    }
}
