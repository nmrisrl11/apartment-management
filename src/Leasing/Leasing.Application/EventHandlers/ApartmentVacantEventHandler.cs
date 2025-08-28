using ApartmentManagement.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandlers
{
    public class ApartmentVacantEventHandler : INotificationHandler<ApartmentVacantEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentVacantEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(ApartmentVacantEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentVacantIntegrationEvent(notification.LeasingAgreement.ApartmentId.Value);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
