using ApartmentManagement.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record CreatedLeasingAgreementIntegrationEvent(Guid Id) : IIntegrationEvent;
}
