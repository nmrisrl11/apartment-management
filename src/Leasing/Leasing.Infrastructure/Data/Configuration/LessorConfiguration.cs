using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class LessorConfiguration : IEntityTypeConfiguration<Lessor>
    {
        public void Configure(EntityTypeBuilder<Lessor> lessor)
        {
            lessor.HasKey(l => l.Id);
            lessor.Property(l => l.Id).IsRequired()
                .HasConversion(l => l.Value, value => new LessorId(value));
        }
    }
}
