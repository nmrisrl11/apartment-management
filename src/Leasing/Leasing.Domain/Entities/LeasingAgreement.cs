using ApartmentManagement.SharedKernel.Entities;
using Leasing.Domain.DomainEvents;
using Leasing.Domain.Enums;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingAgreement : Entity
    {
        public LeasingAgreementId Id { get; private set; } = null!;
        public LesseeId LesseeId { get; private set; } = null!;
        public Lessee Lessee { get; private set; } = null!;
        public LessorId LessorId { get; private set; } = null!;
        public Lessor Lessor { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; } = null!;
        public Apartment Apartment { get; private set; } = null!;
        public  AgreementStatus Status { get; private set; }
        public DateTime DateCommenced { get; private set; }
        public DateTime DateExpiry { get; private set; }

        protected LeasingAgreement() { }

        // Private constructor for internal use by the static factory method
        private LeasingAgreement(
            LeasingAgreementId id,
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateCommenced,
            DateTime dateExpiry)
        {
            Id = id;
            LesseeId = lesseeId;
            LessorId = lessorId;
            ApartmentId = apartmentId;
            Status = AgreementStatus.NEW;
            DateCommenced = dateCommenced;
            DateExpiry = dateExpiry;
        }

        public static LeasingAgreement Create(
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateCommenced,
            DateTime dateExpiry)
        {
            var newLeasingAgreement = new LeasingAgreement(
                new LeasingAgreementId(Guid.NewGuid()),
                lesseeId,
                lessorId,
                apartmentId,
                dateCommenced,
                dateExpiry);

            newLeasingAgreement.RaiseDomainEvent(new CreatedLeasingAgreementEvent(newLeasingAgreement));

            return newLeasingAgreement;
        }

        public void Renew()
        {
            Status = AgreementStatus.RENEWED;
            DateExpiry = DateExpiry.AddYears(1);
        }

        public void Terminate()
        {
            Status = AgreementStatus.TERMINATED;
            this.RaiseDomainEvent(new TerminatedLeasingAgreementEvent(this));
        }
    }
}
