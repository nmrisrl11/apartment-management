using Property.Application.Response;

namespace Property.Application.Commands
{
    public interface IOwnerCommands
    {
        Task<OwnerResponse> AddAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
