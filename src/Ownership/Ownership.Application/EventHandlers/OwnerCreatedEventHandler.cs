using ApartmentManagement.Contracts.Services;
using MediatR;
using Ownership.Domain.DomainEvents;
using Ownership.IntegrationEvent;

namespace Ownership.Application.EventHandlers
{
    public class OwnerCreatedEventHandler : INotificationHandler<OwnerCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public OwnerCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(OwnerCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new OwnerCreatedIntegrationEvent(
                notification.Owner.Id.Value,
                notification.Owner.Name);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
