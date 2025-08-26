using Leasing.Application.Queries;
using Leasing.Domain.Repositories;
using Leasing.Infrastructure.Data;
using Leasing.Infrastructure.Data.Repositories;
using Leasing.Infrastructure.QueryHandler;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LeasingDbContext>(o =>
            {
                o.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    sql => sql.MigrationsHistoryTable("_EFMigrationsHistory", "Leasing"));
            });

            // Repositories
            services.AddScoped<ILeasingAgreementRepository, LeasingAgreementRepository>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();
            services.AddScoped<IApartmentRepository, ApartmentRepository>();
            services.AddScoped<ILeasingRecordRepository, LeasingRecordRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Queries
            services.AddScoped<ILeasingAgreementQueries, LeasingAgreementQueries>();
            services.AddScoped<IOwnerQueries, OwnerQueries>();
            services.AddScoped<IApartmentQueries, ApartmentQueries>();

            return services;
        }
    }
}
