using ApartmentManagement.SharedKernel;
using MediatR;

namespace ApartmentManagement.Contracts.Services
{
    public class DomainEventPublisher : IDomainEventPublisher
    {
        private readonly IPublisher _publisher;

        public DomainEventPublisher(IPublisher publisher)
        {
            _publisher = publisher;
        }

        public async Task PublishAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken)
        {
            foreach (var @event in domainEvents)
            {
                await _publisher.Publish(@event);
            }
        }
    }
}
