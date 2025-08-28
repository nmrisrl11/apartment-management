using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Property.Application.Queries;
using Property.Domain.Repositories;
using Property.Infrastructure.Data;
using Property.Infrastructure.Data.Repositories;
using Property.Infrastructure.QueryHandler;

namespace Property.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPropertyInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<PropertyDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Property"));
            });

            // Repositories
            services.AddScoped<IApartmentUnitRepository, ApartmentUnitRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Queries
            services.AddScoped<IApartmentUnitQueries, ApartmentUnitQueries>();

            return services;
        }
    }
}
