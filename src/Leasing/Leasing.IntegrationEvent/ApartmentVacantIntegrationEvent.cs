using ApartmentManagement.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record ApartmentVacantIntegrationEvent(Guid Id) : IIntegrationEvent;
}
