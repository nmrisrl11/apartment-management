namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IApartmentRepository Apartments { get; }
        IOwnerRepository Owners { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
