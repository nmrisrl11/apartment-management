using FluentResults;
using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface IOwnerCommands
    {
        Task<OwnerResponse> AddAsync(string name, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
