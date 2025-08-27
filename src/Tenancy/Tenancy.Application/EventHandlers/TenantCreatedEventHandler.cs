using ApartmentManagement.Contracts.Services;
using MediatR;
using Tenancy.Domain.DomainEvents;
using Tenancy.IntegrationEvent;


namespace Tenancy.Application.EventHandlers
{
    public class TenantCreatedEventHandler : INotificationHandler<TenantCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public TenantCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(TenantCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new TenantCreatedIntegrationEvent(
                notification.Tenant.Id.Value,
                notification.Tenant.Name,
                notification.Tenant.Email,
                notification.Tenant.ContactNumber);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
