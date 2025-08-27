using FluentResults;
using Tenancy.Application.Response;

namespace Tenancy.Application.Commands
{
    public interface ITenantCommands
    {
        Task<TenantResponse> AddAsync(string name, string email, string contactNumber, CancellationToken cancellationToken);
        Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<Result> UpdateAsync(Guid id, string name, string email, string contactNumber, CancellationToken cancellationToken);
    }
}
