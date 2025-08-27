namespace Ownership.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IOwnerRepository Owners { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
