using ApartmentManagement.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandlers.Domain
{
    public class ApartmentUnitFinishedUnderMaintenanceEventHandler : INotificationHandler<ApartmentUnitFinishedUnderMaintenanceEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentUnitFinishedUnderMaintenanceEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ApartmentUnitFinishedUnderMaintenanceEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentUnitFinishedUnderMaintenanceIntegrationEvent(notification.ApartmentUnit.Id.Value);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
