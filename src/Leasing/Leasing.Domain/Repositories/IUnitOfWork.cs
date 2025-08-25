namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ILeasingAgreementRepository LeasingAgreements { get; }
        IOwnerRepository Owners { get; }
        IApartmentRepository Apartments { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
