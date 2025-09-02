using Billing.Domain.Entities;
using Billing.Domain.Repositories;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Billing.Infrastructure.Data.Repositories
{
    public class LeasingAgreementRepository : ILeasingAgreementRepository
    {
        private readonly BillingDbContext _context;

        public LeasingAgreementRepository(BillingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LeasingAgreement leasingAgreement)
        {
            await _context.LeasingAgreements.AddAsync(leasingAgreement);
        }

        public async Task<LeasingAgreement?> GetByIdAsync(LeasingAgreementId id)
        {
            return await _context.LeasingAgreements.Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
