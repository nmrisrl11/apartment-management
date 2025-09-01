namespace Billing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
