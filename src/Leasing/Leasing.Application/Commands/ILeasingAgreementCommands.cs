using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILeasingAgreementCommands
    {
        Task<LeasingAgreementResponse> AddAsync(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            Guid ownerId,
            Guid apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal,
            CancellationToken cancellationToken);
    }
}
