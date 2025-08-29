using Leasing.Domain.Enums;
using Leasing.Domain.Exceptions;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Apartment
    {
        public ApartmentId Id { get; private set; } = null!;
        public LessorId LessorId { get; private set; } = null!;
        public Lessor Lessor { get; private set; } = null!;
        public string BuildingNumber { get; private set; } = null!;
        public string ApartmentNumber { get; private set; } = null!;
        public ApartmentStatus Status { get; private set; }
        public List<LeasingRecord> LeasingHistory { get; set; } = [];

        protected Apartment() { }

        public static Apartment Create(Guid id, Guid lessorId, string buildingNumber, string apartmentNumber)
        {
            return new Apartment
            {
                Id = new ApartmentId(id),
                LessorId = new LessorId(lessorId),
                BuildingNumber = buildingNumber,
                ApartmentNumber = apartmentNumber,
                Status = ApartmentStatus.AVAILABLE
            };
        }

        public void Update(string buildingNumber, string apartmentNumber)
        {
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
        }

        public void MarkAsAvailable()
        {
            if(Status == ApartmentStatus.AVAILABLE)
                throw new ApartmentAlreadyAvailableException("Apartment is already available.");

            Status = ApartmentStatus.AVAILABLE;
        }

        public void MarkAsLeased()
        {
            if(Status == ApartmentStatus.UNAVAILABLE)
                throw new ApartmentIsCurrentlyUnavailableException("Sorry, this aparment is currently unavailable.");

            if(Status == ApartmentStatus.LEASED)
                throw new ApartmentAlreadyLeasedException("Apartment is already leased.");

            Status  = ApartmentStatus.LEASED;
        }

        public void MarkAsUnavailable()
        {
            if (Status == ApartmentStatus.UNAVAILABLE)
                throw new ApartmentAlreadyUnavailableException("Apartment is already unavailable.");

            Status = ApartmentStatus.UNAVAILABLE;
        }
    }
}
