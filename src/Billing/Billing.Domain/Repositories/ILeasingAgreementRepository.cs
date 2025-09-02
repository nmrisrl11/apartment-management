using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Repositories
{
    public interface ILeasingAgreementRepository
    {
        Task AddAsync(LeasingAgreement leasingAgreement);
        Task<LeasingAgreement?> GetByIdAsync(LeasingAgreementId id);
    }
}
