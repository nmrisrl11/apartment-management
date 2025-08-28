using ApartmentManagement.SharedKernel;
using Leasing.Domain.Entities;

namespace Leasing.Domain.DomainEvents
{
    public record ApartmentOccupiedEvent(LeasingAgreement LeasingAgreement) : IDomainEvent;
}
