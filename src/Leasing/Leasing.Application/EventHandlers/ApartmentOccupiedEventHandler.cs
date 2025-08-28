using ApartmentManagement.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandlers
{
    public class ApartmentOccupiedEventHandler : INotificationHandler<ApartmentOccupiedEvent>
    {
        private readonly IEventBus _eventBus;

        public ApartmentOccupiedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public async Task Handle(ApartmentOccupiedEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new ApartmentOccupiedIntegrationEvent(
                notification.LeasingAgreement.ApartmentId.Value,
                notification.LeasingAgreement.Status.ToString());

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
