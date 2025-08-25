using Leasing.Application.Response;

namespace Leasing.Application.Queries
{
    public interface ILeasingAgreementQueries
    {
        Task<LeasingAgreementResponse?> GetByIdAsync(Guid id);
        Task<List<LeasingAgreementResponse>> GetAllAsync();
    }
}
