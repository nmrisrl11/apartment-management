using Microsoft.EntityFrameworkCore;
using Ownership.Domain.Entities;

namespace Ownership.Infrastructure.Data
{
    public class OwnershipDbContext : DbContext
    {
        public OwnershipDbContext(DbContextOptions<OwnershipDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Ownership");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(OwnershipDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Owner> Owners { get; set; }
    }
}
