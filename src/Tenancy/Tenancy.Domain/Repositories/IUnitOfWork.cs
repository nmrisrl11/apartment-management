namespace Tenancy.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ITenantRepository Tenants { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
