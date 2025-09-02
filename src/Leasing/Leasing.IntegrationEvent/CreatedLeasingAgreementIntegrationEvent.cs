using ApartmentManagement.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record CreatedLeasingAgreementIntegrationEvent(
        Guid LeasingAgreementId,
        Guid ApartmentId) : IIntegrationEvent;
}
