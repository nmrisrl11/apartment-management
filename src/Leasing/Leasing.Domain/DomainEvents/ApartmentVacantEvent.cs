using ApartmentManagement.SharedKernel;
using Leasing.Domain.Entities;

namespace Leasing.Domain.DomainEvents
{
    public record ApartmentVacantEvent(LeasingAgreement LeasingAgreement) : IDomainEvent;
}
