using ApartmentManagement.SharedKernel;

namespace Property.IntegrationEvent
{
    public record ApartmentUnitFinishedUnderMaintenanceIntegrationEvent(Guid Id) : IIntegrationEvent;
}