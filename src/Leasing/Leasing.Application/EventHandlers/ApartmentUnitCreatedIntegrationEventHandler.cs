using Leasing.Application.Commands;
using MediatR;
using Property.IntegrationEvent;

namespace Leasing.Application.EventHandlers
{
    public class ApartmentUnitCreatedIntegrationEventHandler : INotificationHandler<ApartmentUnitCreatedIntegrationEvent>
    {
        private readonly IApartmentCommands _apartmentCommands;

        public ApartmentUnitCreatedIntegrationEventHandler(IApartmentCommands apartmentCommands)
        {
            _apartmentCommands = apartmentCommands;
        }

        public async Task Handle(ApartmentUnitCreatedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            await _apartmentCommands.AddAsync(
                notification.Id,
                notification.OwnerId,
                notification.BuildingNumber,
                notification.ApartmentNumber,
                cancellationToken);
        }
    }
}
