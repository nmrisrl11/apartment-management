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
            services.AddScoped<ITenantCommands, TenantCommands>();
            services.AddScoped<ILeasingAgreementCommands, LeasingAgreementCommands>();
            services.AddScoped<IPaymentCommands, PaymentCommands>();

            return services;
        }
    }
}
