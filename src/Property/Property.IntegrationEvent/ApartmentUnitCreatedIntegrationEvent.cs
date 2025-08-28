using ApartmentManagement.SharedKernel;

namespace Property.IntegrationEvent
{
    public record ApartmentUnitCreatedIntegrationEvent(
        Guid Id,
        Guid OwnerId,
        string BuildingNumber,
        string ApartmentNumber) : IIntegrationEvent;
}