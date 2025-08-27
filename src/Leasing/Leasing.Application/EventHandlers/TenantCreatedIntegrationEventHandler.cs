using Leasing.Application.Commands;
using MediatR;
using Tenancy.IntegrationEvent;

namespace Leasing.Application.EventHandlers
{
    public class TenantCreatedIntegrationEventHandler : INotificationHandler<TenantCreatedIntegrationEvent>
    {
        private readonly ILesseeCommands _lesseeCommands;

        public TenantCreatedIntegrationEventHandler(ILesseeCommands lesseeCommands)
        {
            _lesseeCommands = lesseeCommands;
        }

        public async Task Handle(TenantCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _lesseeCommands.AddAsync(
                notification.Id,
                notification.Name,
                notification.Email,
                notification.ContactNumber,
                cancellationToken);
        }
    }
}
