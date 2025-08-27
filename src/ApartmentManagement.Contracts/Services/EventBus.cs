﻿using ApartmentManagement.SharedKernel;
using MediatR;

namespace ApartmentManagement.Contracts.Services
{
    public class EventBus : IEventBus
    {
        private readonly IPublisher _publisher;

        public EventBus(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task PublishAsync(IIntegrationEvent integrationEvent, CancellationToken cancellationToken)
        {
            await _publisher.Publish(integrationEvent, cancellationToken);
        }
    }
}
