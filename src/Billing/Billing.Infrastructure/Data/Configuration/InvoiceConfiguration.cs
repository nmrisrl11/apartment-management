using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Infrastructure.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> invoice)
        {
            invoice.HasKey(i => i.Id);
            invoice.Property(i => i.Id).IsRequired()
                .HasConversion(i => i.Value, value => new InvoiceId(value));
            invoice.Property(i => i.TenantId)
                .HasConversion(i => i.Value, value => new TenantId(value));
            invoice.Property(i => i.LeasingAgreementId)
                .HasConversion(i => i.Value, value => new LeasingAgreementId(value));

        }
    }
}