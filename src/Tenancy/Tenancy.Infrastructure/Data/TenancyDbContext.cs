using Microsoft.EntityFrameworkCore;
using Tenancy.Domain.Entities;

namespace Tenancy.Infrastructure.Data
{
    public class TenancyDbContext : DbContext
    {
        public TenancyDbContext(DbContextOptions<TenancyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Tenancy");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TenancyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Tenant> Tenants { get; set; }
    }
}
