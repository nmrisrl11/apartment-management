namespace Property.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IApartmentUnitRepository ApartmentUnits { get; }
        IOwnerRepository Owners { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
