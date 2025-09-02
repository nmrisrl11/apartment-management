using ApartmentManagement.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandlers.Domain
{
    public class CreatedLeasingAgreementEventHandler : INotificationHandler<CreatedLeasingAgreementEvent>
    {
        private readonly IEventBus _eventBus;

        public CreatedLeasingAgreementEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public async Task Handle(CreatedLeasingAgreementEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new CreatedLeasingAgreementIntegrationEvent(
                notification.LeasingAgreement.Id.Value,
                notification.LeasingAgreement.ApartmentId.Value);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
