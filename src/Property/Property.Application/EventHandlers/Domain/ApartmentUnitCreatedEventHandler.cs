using ApartmentManagement.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandlers.Domain
{
    public class ApartmentUnitCreatedEventHandler : INotificationHandler<ApartmentUnitCreatedEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentUnitCreatedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ApartmentUnitCreatedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentUnitCreatedIntegrationEvent(
                notification.ApartmentUnit.Id.Value,
                notification.ApartmentUnit.OwnerId.Value,
                notification.ApartmentUnit.BuildingNumber,
                notification.ApartmentUnit.ApartmentNumber);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
