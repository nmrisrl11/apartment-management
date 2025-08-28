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
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }

        protected LeasingAgreement() { }

        // Private constructor for internal use by the static factory method
        private LeasingAgreement(
            LeasingAgreementId id,
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            Id = id;
            LesseeId = lesseeId;
            LessorId = lessorId;
            ApartmentId = apartmentId;
            Status = AgreementStatus.NEW;
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
        }

        public static LeasingAgreement Create(
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            var newLeasingAgreement = new LeasingAgreement(
                new LeasingAgreementId(Guid.NewGuid()),
                lesseeId,
                lessorId,
                apartmentId,
                dateLeased,
                dateRenewal);

            newLeasingAgreement.RaiseDomainEvent(new ApartmentOccupiedEvent(newLeasingAgreement));

            return newLeasingAgreement;
        }

        public void Renew()
        {
            Status = AgreementStatus.RENEWED;
            DateRenewal = DateRenewal.AddDays(30);
        }
    }
}
