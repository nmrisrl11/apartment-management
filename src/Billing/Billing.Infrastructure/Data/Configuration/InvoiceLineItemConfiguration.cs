using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Infrastructure.Data.Configuration
{
    public class InvoiceLineItemConfiguration : IEntityTypeConfiguration<InvoiceLineItem>
    {
        public void Configure(EntityTypeBuilder<InvoiceLineItem> invoiceLineItem)
        {
            invoiceLineItem.HasKey(ili => ili.Id);
            invoiceLineItem.Property(ili => ili.Id).IsRequired()
                .HasConversion(ili => ili.Value, value => new InvoiceLineItemId(value));
            invoiceLineItem.Property(ili => ili.InvoiceId)
                .HasConversion(ili => ili.Value, value => new InvoiceId(value));

            invoiceLineItem.Property(ili => ili.Quantity).HasColumnType("decimal(18, 4)");

            // Configure the Money Value Object as an "Owned Type"
            // This tells EF Core to store the Money properties as columns in this same table
            // It will create columns like: UnitPrice_Amount, UnitPrice_Currency
            invoiceLineItem.OwnsOne(ili => ili.UnitPrice, price =>
            {
                price.Property(p => p.Amount).HasColumnName("UnitPrice_Amount").HasColumnType("decimal(18,2)");
                price.Property(p => p.Currency).HasColumnName("UnitPrice_Currency").HasMaxLength(3);
            });

            // The TotalPrice is a calculated property in the domain, so we tell EF to ignore it
            invoiceLineItem.Ignore(ili => ili.TotalPrice);

            // We don't need to configure the foreign key here, 
            // it's best practice to configure the relationship from the parent (Invoice).
        }
    }
}