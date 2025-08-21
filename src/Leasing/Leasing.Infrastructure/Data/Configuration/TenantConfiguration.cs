using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> tenant)
        {
            tenant.HasKey(t => t.Id);
            tenant.Property(t => t.Id).IsRequired()
                .HasConversion(t => t.Value, value => new TenantId(value));
        }
    }
}
