namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ILeasingAgreementRepository LeasingAgreements { get; }
        IOwnerRepository Owners { get; }
        IApartmentRepository Apartments { get; }
        ILeasingRecordRepository LeasingRecords { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
