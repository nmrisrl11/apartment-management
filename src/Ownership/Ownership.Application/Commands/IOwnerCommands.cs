using FluentResults;
using Ownership.Application.Response;

namespace Ownership.Application.Commands
{
    public interface IOwnerCommands
    {
        Task<OwnerResponse> AddAsync(string name, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
