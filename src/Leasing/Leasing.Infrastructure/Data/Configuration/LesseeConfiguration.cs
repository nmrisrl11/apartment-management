using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class LesseeConfiguration : IEntityTypeConfiguration<Lessee>
    {
        public void Configure(EntityTypeBuilder<Lessee> lessee)
        {
            lessee.HasKey(l => l.Id);
            lessee.Property(l => l.Id).IsRequired()
                .HasConversion(t => t.Value, value => new LesseeId(value));
        }
    }
}
