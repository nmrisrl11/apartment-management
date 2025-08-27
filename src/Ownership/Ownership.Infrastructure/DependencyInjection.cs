using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Ownership.Application.Queries;
using Ownership.Domain.Repositories;
using Ownership.Infrastructure.Data;
using Ownership.Infrastructure.Data.Repositories;
using Ownership.Infrastructure.QueryHandler;

namespace Ownership.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnershipInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<OwnershipDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Ownership"));
            });

            // Repositories
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Queries
            services.AddScoped<IOwnerQueries, OwnerQueries>();

            return services;
        }
    }
}
