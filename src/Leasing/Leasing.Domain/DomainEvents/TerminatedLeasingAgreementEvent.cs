using ApartmentManagement.SharedKernel;
using Leasing.Domain.Entities;

namespace Leasing.Domain.DomainEvents
{
    public record TerminatedLeasingAgreementEvent(LeasingAgreement LeasingAgreement) : IDomainEvent;
}
