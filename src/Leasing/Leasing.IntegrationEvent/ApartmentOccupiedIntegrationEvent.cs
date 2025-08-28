using ApartmentManagement.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record ApartmentOccupiedIntegrationEvent(Guid Id, string Status) : IIntegrationEvent;
}
