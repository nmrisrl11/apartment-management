using ApartmentManagement.SharedKernel;

namespace Ownership.IntegrationEvent
{
    public record OwnerCreatedIntegrationEvent(Guid Id, string Name) : IIntegrationEvent;
}