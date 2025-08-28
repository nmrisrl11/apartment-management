using Microsoft.EntityFrameworkCore;
using Property.Domain.Entities;

namespace Property.Infrastructure.Data
{
    public class PropertyDbContext : DbContext
    {
        public PropertyDbContext(DbContextOptions<PropertyDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Property");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PropertyDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ApartmentUnit> ApartmentUnits { get; set; }
        public DbSet<Owner> Owners {  get; set; }
    }
}
