using FluentResults;
using Property.Application.Response;

namespace Property.Application.Commands
{
    public interface IApartmentUnitCommands
    {
        Task<Result<ApartmentUnitResponse>> AddAsync(
            Guid ownerId,
            string buildingNumber,
            string ApartmentNumber,
            CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(
            Guid id,
            string buildingNumber,
            string apartmentNumber,
            CancellationToken cancellationToken);
    }
}
