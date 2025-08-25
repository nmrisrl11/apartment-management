using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ILeasingAgreementRepository
    {
        Task AddAsync(LeasingAgreement leasingAgreement);
        Task<LeasingAgreement?> GetByIdAsync(LeasingAgreementId leasingAgreementId);
    }
}
