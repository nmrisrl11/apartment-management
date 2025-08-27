using Microsoft.Extensions.DependencyInjection;
using Tenancy.Application.CommandHandler;
using Tenancy.Application.Commands;

namespace Tenancy.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTenancyApplication(this IServiceCollection services)
        {
            services.AddScoped<ITenantCommands, TenantCommands>();

            return services;
        }
    }
}
