using Microsoft.Extensions.DependencyInjection;
using Ownership.Application.CommandHandler;
using Ownership.Application.Commands;

namespace Ownership.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddOwnershipApplication(this IServiceCollection services)
        {
            services.AddScoped<IOwnerCommands, OwnerCommands>();

            return services;
        }
    }
}
