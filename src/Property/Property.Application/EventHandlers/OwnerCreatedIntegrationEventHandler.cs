using MediatR;
using Ownership.IntegrationEvent;
using Property.Application.Commands;

namespace Property.Application.EventHandlers
{
    public class OwnerCreatedIntegrationEventHandler : INotificationHandler<OwnerCreatedIntegrationEvent>
    {
        private readonly IOwnerCommands _ownerCommands;

        public OwnerCreatedIntegrationEventHandler(IOwnerCommands ownerCommands)
        {
            _ownerCommands = ownerCommands;
        }

        public async Task Handle(OwnerCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _ownerCommands.AddAsync(notification.Id, notification.Name, cancellationToken);
        }
    }
}
