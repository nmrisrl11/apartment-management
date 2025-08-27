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
            Guid lessorId,
            Guid apartmentId,
            CancellationToken cancellationToken);

        Task<Result> RenewAsync(
            Guid leasingAgreementId,
            Guid tenantId,
            Guid lessorId,
            Guid apartmentId,
            CancellationToken cancellationToken);
    }
}
