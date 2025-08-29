using ApartmentManagement.Contracts.Services;
using MediatR;
using Property.Domain.DomainEvents;
using Property.IntegrationEvent;

namespace Property.Application.EventHandlers
{
    public class ApartmentUnitStartedUnderMaintenanceEventHandler : INotificationHandler<ApartmentUnitStartedUnderMaintenanceEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentUnitStartedUnderMaintenanceEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ApartmentUnitStartedUnderMaintenanceEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentUnitStartedUnderMaintenanceIntegrationEvent(notification.ApartmentUnit.Id.Value);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
