using Leasing.Application.Commands;
using MediatR;
using Ownership.IntegrationEvent;

namespace Leasing.Application.EventHandlers
{
    public class OwnerCreatedIntegrationEventHandler : INotificationHandler<OwnerCreatedIntegrationEvent>
    {
        private readonly ILessorCommands _lessorCommands;

        public OwnerCreatedIntegrationEventHandler(ILessorCommands lessorCommands)
        {
            _lessorCommands = lessorCommands;
        }

        public async Task Handle(OwnerCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _lessorCommands.AddAsync(notification.Id, notification.Name, cancellationToken);
        }
    }
}
