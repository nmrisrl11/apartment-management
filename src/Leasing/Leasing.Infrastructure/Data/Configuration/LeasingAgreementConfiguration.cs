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
            leasingAgreement.HasKey(la => la.Id);
            leasingAgreement.Property(la => la.Id).IsRequired()
                .HasConversion(la => la.Value, value => new LeasingAgreementId(value));
            leasingAgreement.Property(la => la.TenantId)
                .HasConversion(la => la.Value, value => new TenantId(value));
            leasingAgreement.Property(la => la.LessorId)
                .HasConversion(la => la.Value, value => new LessorId(value));
            leasingAgreement.Property(la => la.ApartmentId)
                .HasConversion(la => la.Value, value => new ApartmentId(value));
        }
    }
}