using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tenancy.Domain.Entities;
using Tenancy.Domain.ValueObjects;

namespace Tenancy.Infrastructure.Data.Configuration
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> tenant)
        {
            tenant.HasKey(o => o.Id);
            tenant.Property(o => o.Id).IsRequired()
                .HasConversion(o => o.Value, value => new TenantId(value));

        }
    }
}