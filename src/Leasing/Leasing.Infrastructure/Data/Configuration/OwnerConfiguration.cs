using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class OwnerConfiguration : IEntityTypeConfiguration<Owner>
    {
        public void Configure(EntityTypeBuilder<Owner> owner)
        {
            owner.HasKey(o => o.Id);
            owner.Property(o => o.Id).IsRequired()
                .HasConversion(o => o.Value, value => new OwnerId(value));

        }
    }
}
