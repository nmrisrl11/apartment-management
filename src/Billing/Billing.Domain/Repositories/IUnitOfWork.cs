namespace Billing.Domain.Repositories
{
    public interface IUnitOfWork
    {
        IInvoiceRepository Invoices { get; }
        ITenantRepository Tenants { get; }
        ILeasingAgreementRepository LeasingAgreements { get; }
        Task SaveChangesAsync(CancellationToken cancellationToken);
    }
}
