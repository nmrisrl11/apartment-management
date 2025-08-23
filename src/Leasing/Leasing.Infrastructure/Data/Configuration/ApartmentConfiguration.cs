using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class ApartmentConfiguration : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> apartment)
        {
            apartment.HasKey(a => a.Id);
            apartment.Property(a => a.Id)
                .HasConversion(a => a.Value, value => new ApartmentId(value));

            // Add this configuration for the Owner relationship
            apartment.HasOne(a => a.Owner)
                .WithMany() // Assuming a one-to-many or one-to-one relationship from the Owner's side
                .HasForeignKey(a => a.OwnerId)
                .IsRequired(false); // Or true, depending on your business logic

            // Map the OwnerId Value Object property as a foreign key
            apartment.Property(a => a.OwnerId)
                .HasConversion(oid => oid.Value, value => new OwnerId(value));
        }
    }
}
