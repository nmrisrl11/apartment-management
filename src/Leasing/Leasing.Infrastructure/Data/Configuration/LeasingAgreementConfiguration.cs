using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leasing.Infrastructure.Data.Configuration
{
    public class LeasingAgreementConfiguration : IEntityTypeConfiguration<LeasingAgreement>
    {
        public void Configure(EntityTypeBuilder<LeasingAgreement> leasingAgreement)
        {
            leasingAgreement.HasKey(t => t.Id);
            leasingAgreement.Property(t => t.Id).IsRequired()
                .HasConversion(t => t.Value, value => new LeasingAgreementId(value));
            leasingAgreement.Property(lr => lr.TenantId)
                .HasConversion(lr => lr.Value, value => new TenantId(value));
            leasingAgreement.Property(lr => lr.OwnerId)
                .HasConversion(lr => lr.Value, value => new OwnerId(value));
            leasingAgreement.Property(lr => lr.ApartmentId)
                .HasConversion(lr => lr.Value, value => new ApartmentId(value));
        }
    }
}