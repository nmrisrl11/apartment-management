namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IApartmentRepository Apartments { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
