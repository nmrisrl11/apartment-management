using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class LeasingRecordConfiguration : IEntityTypeConfiguration<LeasingRecord>
    {
        public void Configure(EntityTypeBuilder<LeasingRecord> leasingRecord)
        {
            leasingRecord.HasKey(lr => lr.Id);
            leasingRecord.Property(lr => lr.Id)
                .HasConversion(lr => lr.Value, value => new LeasingRecordId(value));
            leasingRecord.Property(lr => lr.TenantId)
                .HasConversion(lr => lr.Value, value => new TenantId(value));
            leasingRecord.Property(lr => lr.LessorId)
                .HasConversion(lr => lr.Value, value => new LessorId(value));
            leasingRecord.Property(lr => lr.ApartmentId)
                .HasConversion(lr => lr.Value, value => new ApartmentId(value));
        }
    }
}
