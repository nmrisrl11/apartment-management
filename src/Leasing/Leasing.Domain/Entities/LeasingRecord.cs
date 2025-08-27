using Leasing.Domain.Enums;
using Leasing.Domain.Exceptions;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class LeasingRecord
    {
        public LeasingRecordId Id { get; private set; } = null!;
        public LesseeId LesseeId { get; private set; } = null!;
        public Lessee Lessee { get; private set; } = null!;
        public LessorId LessorId { get; private set; } = null!;
        public Lessor Lessor { get; private set; } = null!;
        public ApartmentId ApartmentId { get; private set; } = null!;
        public Apartment Apartment { get; private set; } = null!;
        public DateTime DateLeased { get; private set; }
        public DateTime DateRenewal { get; private set; }
        public LeasingRecordStatus Status { get; set; }

        private LeasingRecord(LeasingRecordId id,
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
            DateLeased = dateLeased;
            DateRenewal = dateRenewal;
            Status = LeasingRecordStatus.ACTIVE;
        }

        public static LeasingRecord Create(
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateLeased,
            DateTime dateRenewal)
        {
            return new LeasingRecord(
                new LeasingRecordId(Guid.NewGuid()),
                lesseeId,
                lessorId,
                apartmentId,
                dateLeased,
                dateRenewal);
        }

        public void Process()
        {
            if (Status == LeasingRecordStatus.ENDED)
                throw new LeasingContractAlreadyEndedException("The leasing contract already ended.");
            
            Status = LeasingRecordStatus.ENDED;
            Apartment.MarkAsVacant();
        }

        public void AdjustDateRenewal()
        {
            DateRenewal = DateRenewal.AddDays(30);
        }
    }
}
