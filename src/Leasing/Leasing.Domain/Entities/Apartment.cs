using Leasing.Domain.Enums;
using Leasing.Domain.Exceptions;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Apartment
    {
        public ApartmentId Id { get; private set; } = null!;
        public string BuildingNumber { get; private set; } = null!;
        public string ApartmentNumber { get; private set; } = null!;
        public ApartmentStatus Status { get; private set; }
        public List<LeasingRecord> LeasingHistory { get; set; } = [];

        protected Apartment() { }

        public static Apartment Create(string buildingNumber, string apartmentNumber)
        {
            return new Apartment
            {
                Id = new ApartmentId(Guid.NewGuid()),
                BuildingNumber = buildingNumber,
                ApartmentNumber = apartmentNumber,
                Status = ApartmentStatus.VACANT
            };
        }

        public void Update(string buildingNumber, string apartmentNumber)
        {
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
        }

        public void MarkAsOccupied()
        {
            if(Status == ApartmentStatus.UNDER_MAINTENANCE)
                throw new ApartmentIsCurrentlyUnderMaintenanceException("Sorry, this aparment is currently under maintenance.");

            if(Status == ApartmentStatus.OCCUPIED)
                throw new ApartmentAlreadyOccupiedException("Apartment is already occupied.");

            Status  = ApartmentStatus.OCCUPIED;
        }

        public void MarkAsUnderMaintenance()
        {
            if (Status == ApartmentStatus.UNDER_MAINTENANCE)
                throw new ApartmentAlreadyUnderMaintenanceException("Apartment is already under maintenance.");

            Status = ApartmentStatus.UNDER_MAINTENANCE;
        }
    }
}
