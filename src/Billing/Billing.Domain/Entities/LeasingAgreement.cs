using ApartmentManagement.SharedKernel.Entities;
using Billing.Domain.ValueObjects;

namespace Billing.Domain.Entities
{
    public class LeasingAgreement : Entity
    {
        public LeasingAgreementId Id { get; private set; } = null!;

        public static LeasingAgreement Create(Guid id)
        {
           return new LeasingAgreement
           {
               Id = new LeasingAgreementId(id)
           };
        }
    }
}
