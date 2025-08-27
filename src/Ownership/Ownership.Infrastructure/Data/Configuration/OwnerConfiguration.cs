using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ownership.Domain.Entities;
using Ownership.Domain.ValueObjects;

namespace Ownership.Infrastructure.Data.Configuration
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