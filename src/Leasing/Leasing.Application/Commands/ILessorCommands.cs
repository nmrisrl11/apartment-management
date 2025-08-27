using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILessorCommands
    {
        Task<LessorResponse> AddAsync(Guid id, string name, CancellationToken cancellationToken);
    }
}
