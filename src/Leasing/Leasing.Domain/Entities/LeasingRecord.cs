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
        public DateTime DateCommenced { get; private set; }
        public DateTime DateExpiry { get; private set; }
        public LeasingRecordStatus Status { get; set; }

        private LeasingRecord(LeasingRecordId id,
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
            DateCommenced = dateCommenced;
            DateExpiry = dateExpiry;
            Status = LeasingRecordStatus.ACTIVE;
        }

        public static LeasingRecord Create(
            LesseeId lesseeId,
            LessorId lessorId,
            ApartmentId apartmentId,
            DateTime dateCommenced,
            DateTime dateExpiry)
        {
            return new LeasingRecord(
                new LeasingRecordId(Guid.NewGuid()),
                lesseeId,
                lessorId,
                apartmentId,
                dateCommenced,
                dateExpiry);
        }

        public void AdjustDateRenewal()
        {
            DateExpiry = DateExpiry.AddYears(1);
        }

        public void MarkAsEnded()
        {
            if (Status == LeasingRecordStatus.ENDED)
                throw new LeasingContractAlreadyEndedException("The leasing contract already ended.");

            Status = LeasingRecordStatus.ENDED;
        }
    }
}
