using ApartmentManagement.Contracts.Services;
using Leasing.Domain.DomainEvents;
using Leasing.IntegrationEvent;
using MediatR;

namespace Leasing.Application.EventHandlers
{
    public class TerminatedLeasingAgreementEventHandler : INotificationHandler<TerminatedLeasingAgreementEvent>
    {
        private readonly IEventBus _eventBus;

        public TerminatedLeasingAgreementEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }
        public async Task Handle(TerminatedLeasingAgreementEvent notification, CancellationToken cancellationToken)
        {
            var integrationEvent = new TerminatedLeasingAgreementIntegrationEvent(
                notification.LeasingAgreement.ApartmentId.Value);

            await _eventBus.PublishAsync(integrationEvent, cancellationToken);
        }
    }
}
