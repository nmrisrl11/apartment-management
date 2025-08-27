namespace Leasing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        ILeasingAgreementRepository LeasingAgreements { get; }
        ILesseeRepository Lessees { get; }
        ILessorRepository Lessors { get; }
        IApartmentRepository Apartments { get; }
        ILeasingRecordRepository LeasingRecords { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
