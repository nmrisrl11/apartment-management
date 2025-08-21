using Leasing.Application.CommandHandler;
using Leasing.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Leasing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddLeasingApplication(this IServiceCollection services)
        {
            services.AddScoped<IApartmentCommands, ApartmentCommands>();

            return services;
        }
    }
}
