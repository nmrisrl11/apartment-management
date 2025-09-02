using Billing.Domain.Entities;
using Billing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Billing.Infrastructure.Data.Configuration
{
    public class LeasingAgreementConfiguration : IEntityTypeConfiguration<LeasingAgreement>
    {
        public void Configure(EntityTypeBuilder<LeasingAgreement> leasingAgreement)
        {
            leasingAgreement.HasKey(la => la.Id);
            leasingAgreement.Property(la => la.Id).IsRequired()
                .HasConversion(la => la.Value, value => new LeasingAgreementId(value));
        }
    }
}
