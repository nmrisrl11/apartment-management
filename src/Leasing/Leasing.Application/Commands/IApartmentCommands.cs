using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface IApartmentCommands
    {
        Task<Result<ApartmentResponse>> AddAsync(
            Guid id,
            Guid lessorId,
            string buildingNumber,
            string apartmentNumber,
            CancellationToken cancellationToken);
    }
}
