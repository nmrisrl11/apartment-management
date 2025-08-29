using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILeasingAgreementCommands
    {
        Task<Result> AddAsync(
            Guid lesseeId,
            Guid lessorId,
            Guid apartmentId,
            CancellationToken cancellationToken);

        Task<Result> RenewAsync(
            Guid leasingAgreementId,
            Guid lesseeId,
            Guid lessorId,
            Guid apartmentId,
            CancellationToken cancellationToken);

        Task<Result> TeminateAsync(
            Guid leasingAgreementId,
            Guid lesseeId,
            Guid lessorId,
            Guid apartmentId,
            CancellationToken cancellationToken);
    }
}
