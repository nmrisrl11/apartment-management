using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface IApartmentCommands
    {
        Task<ApartmentResponse> AddAsync(string buildingNumber, string apartmentNumber, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(Guid id, string buildingNumber, string apartmentNumber, CancellationToken cancellationToken);
    }
}
