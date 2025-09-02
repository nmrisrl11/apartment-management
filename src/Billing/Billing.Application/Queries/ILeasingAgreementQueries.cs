using Billing.Application.Response;

namespace Billing.Application.Queries
{
    public interface ILeasingAgreementQueries
    {
        Task<LeasingAgreementResponse?> GetByIdAsync(Guid id);
        Task<List<LeasingAgreementResponse>> GetAllAsync();
    }
}
