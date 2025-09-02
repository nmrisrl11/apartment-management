using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly BillingDbContext _context;

        public PaymentRepository(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Payment payment)
        {
            await _context.Payments.AddAsync(payment);
        }

        public async Task<Payment?> GetByIdAsync(PaymentId id)
        {
            return await _context.Payments.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
