using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Configuration
{
    public class ApartmentUnitConfiguration : IEntityTypeConfiguration<ApartmentUnit>
    {
        public void Configure(EntityTypeBuilder<ApartmentUnit> apartmentUnit)
        {
            apartmentUnit.HasKey(au => au.Id);
            apartmentUnit.Property(au => au.Id).IsRequired()
                .HasConversion(au => au.Value, value => new ApartmentUnitId(value));
            apartmentUnit.Property(au => au.OwnerId)
                .HasConversion(au => au.Value, value => new OwnerId(value));

        }
    }
}