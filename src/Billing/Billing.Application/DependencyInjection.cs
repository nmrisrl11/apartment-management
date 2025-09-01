using Billing.Application.CommandHandler;
using Billing.Application.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace Billing.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBillingApplication(this IServiceCollection services)
        {
            services.AddScoped<IInvoiceCommands, InvoiceCommands>();

            return services;
        }
    }
}
