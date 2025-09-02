using Billing.Application.Commands;
using MediatR;
using Tenancy.IntegrationEvent;

namespace Billing.Application.EventHandlers.Integration
{
    public class TenantCreatedIntegrationEventHandler : INotificationHandler<TenantCreatedIntegrationEvent>
    {
        private readonly ITenantCommands _tenantCommands;

        public TenantCreatedIntegrationEventHandler(ITenantCommands tenantCommands)
        {
            _tenantCommands = tenantCommands;
        }

        public async Task Handle(TenantCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _tenantCommands.AddAsync(
                notification.Id,
                notification.Name,
                cancellationToken);
        }
    }
}
