using ApartmentManagement.SharedKernel;

namespace Tenancy.IntegrationEvent
{
    public record TenantCreatedIntegrationEvent(
        Guid Id,
        string Name,
        string Email,
        string ContactNumber) : IIntegrationEvent;
}
