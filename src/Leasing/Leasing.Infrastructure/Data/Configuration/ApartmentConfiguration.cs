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
        }
    }
}
