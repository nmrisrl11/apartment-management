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

            // --- NEW: Configure the relationship ---
            // This is the most important part.
            invoice.HasMany(i => i.LineItems) // An Invoice has many LineItems
                .WithOne(li => li.Invoice) // Each LineItem has one Invoice
                .HasForeignKey(li => li.InvoiceId) // The foreign key on the LineItem is InvoiceId
                .OnDelete(DeleteBehavior.Cascade); // If you delete an Invoice, delete its LineItems too

            // --- NEW: Configure owned Value Objects ---
            invoice.OwnsOne(i => i.ServicePeriod, period =>
            {
                period.Property(p => p.StartDate).HasColumnName("ServicePeriod_StartDate");
                period.Property(p => p.EndDate).HasColumnName("ServicePeriod_EndDate");
            });

            invoice.OwnsOne(i => i.AmountPaid, money =>
            {
                money.Property(m => m.Amount).HasColumnName("AmountPaid_Amount").HasColumnType("decimal(18,2)");
                money.Property(m => m.Currency).HasColumnName("AmountPaid_Currency").HasMaxLength(3);
            });

            // --- NEW: Tell EF to ignore calculated properties ---
            invoice.Ignore(i => i.Subtotal);
            invoice.Ignore(i => i.TotalAmount);
            invoice.Ignore(i => i.AmountDue);
        }
    }
}