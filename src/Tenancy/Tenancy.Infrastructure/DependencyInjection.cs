using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Tenancy.Application.Queries;
using Tenancy.Domain.Repositories;
using Tenancy.Infrastructure.Data;
using Tenancy.Infrastructure.Data.Repositories;
using Tenancy.Infrastructure.QueryHandler;

namespace Tenancy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenancyInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<TenancyDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Tenancy"));
            });

            // Repositories
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Queries
            services.AddScoped<ITenantQueries, TenantQueries>();

            return services;
        }
    }
}
