using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILeasingAgreementCommands
    {
        Task<Result> AddAsync(
            string tenantName,
            string tenantEmail,
            string tenantContactNumber,
            Guid ownerId,
            Guid apartmentId,
            CancellationToken cancellationToken);

        Task<Result> RenewAsync(
            Guid leasingAgreementId,
            Guid tenantId,
            Guid ownerId,
            Guid apartmentId,
            CancellationToken cancellationToken);
    }
}
