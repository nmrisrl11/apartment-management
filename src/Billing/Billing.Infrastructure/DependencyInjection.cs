using Billing.Application.Queries;
using Billing.Domain.Repositories;
using Billing.Infrastructure.Data;
using Billing.Infrastructure.Data.Repositories;
using Billing.Infrastructure.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBillingInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BillingDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Billing"));
            });

            // Repositories
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Queries
            services.AddScoped<IInvoiceQueries, InvoiceQueries>();
            services.AddScoped<ITenantQueries, TenantQueries>();

            return services;
        }
    }
}
