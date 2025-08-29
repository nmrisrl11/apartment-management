using ApartmentManagement.SharedKernel;

namespace Leasing.IntegrationEvent
{
    public record TerminatedLeasingAgreementIntegrationEvent(Guid Id) : IIntegrationEvent;
}
