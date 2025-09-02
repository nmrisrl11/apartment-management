using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Infrastructure.Data.Configuration
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> payment)
        {
            payment.HasKey(p => p.Id);
            payment.Property(p => p.Id).IsRequired()
                .HasConversion(p => p.Value, value => new PaymentId(value));

            payment.Property(p => p.InvoiceId)
                .HasConversion(p => p.Value, value => new InvoiceId(value));

            payment.OwnsOne(p => p.Amount, amount =>
            {
                amount.Property(p => p.Amount).HasColumnName("Amount").HasColumnType("decimal(18,2)");
                amount.Property(p => p.Currency).HasColumnName("Currency").HasMaxLength(3);
            });
        }
    }
}
