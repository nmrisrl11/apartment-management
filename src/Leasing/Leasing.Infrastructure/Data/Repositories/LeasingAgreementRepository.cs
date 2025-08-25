using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class LeasingAgreementRepository : ILeasingAgreementRepository
    {
        private readonly LeasingDbContext _context;

        public LeasingAgreementRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LeasingAgreement leasingAgreement)
        {
            await _context.LeasingAgreements.AddAsync(leasingAgreement);
        }

        public async Task<LeasingAgreement?> GetByIdAsync(LeasingAgreementId leasingAgreementId)
        {
            return await _context.LeasingAgreements.FindAsync(leasingAgreementId);
        }
    }
}
