using ApartmentManagement.SharedKernel;

namespace Property.IntegrationEvent
{
    public record ApartmentUnitStartedUnderMaintenanceIntegrationEvent(Guid Id) : IIntegrationEvent;
}