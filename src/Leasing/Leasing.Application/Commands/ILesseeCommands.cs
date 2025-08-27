using Leasing.Application.Response;

namespace Leasing.Application.Commands
{
    public interface ILesseeCommands
    {
        Task<LesseeResponse> AddAsync(
            Guid id,
            string name,
            string email,
            string contactNumber,
            CancellationToken cancellationToken);
    }
}
