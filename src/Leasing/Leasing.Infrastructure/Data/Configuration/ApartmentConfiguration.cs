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

            // Add this configuration for the Lessor relationship
            apartment.HasOne(a => a.Lessor)
                .WithMany() // Assuming a one-to-many or one-to-one relationship from the Lessors's side
                .HasForeignKey(a => a.LessorId)
                .IsRequired(false); // Or true, depending on your business logic

            // Map the LessorId Value Object property as a foreign key
            apartment.Property(a => a.LessorId)
                .HasConversion(lid => lid.Value, value => new LessorId(value));
        }
    }
}
