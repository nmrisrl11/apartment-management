using Leasing.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Leasing.Infrastructure.Data
{
    public class LeasingDbContext : DbContext
    {
        public LeasingDbContext(DbContextOptions<LeasingDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Leasing");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LeasingDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<LeasingAgreement> LeasingAgreements { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<LeasingRecord> LeasingRecords { get; set; }
    }
}
