using ApartmentManagement.SharedKernel.Entities;
using Property.Domain.DomainEvents;
using Property.Domain.Enums;
using Property.Domain.ValueObjects;
namespace Property.Domain.Entities
{
    public class ApartmentUnit : Entity
    {
        public ApartmentUnitId Id { get; private set; } = null!;
        public OwnerId OwnerId { get; set; } = null!;
        public Owner Owner { get; set; } = null!;
        public string BuildingNumber { get; private set; } = null!;
        public string ApartmentNumber { get; private set; } = null!;
        public ApartmentUnitStatus Status { get; private set; }

        private ApartmentUnit() { }

        private ApartmentUnit(
            ApartmentUnitId apartmentUnitId,
            OwnerId ownerId,
            string buildingNumber,
            string apartmentNumber)
        {
            Id = apartmentUnitId;
            OwnerId = ownerId;
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
            Status = ApartmentUnitStatus.VACANT;
        }

        public static ApartmentUnit Create(OwnerId ownerId, string buildingNumber, string apartmentNumber)
        {
            var newApartmentUnit = new ApartmentUnit(
                new ApartmentUnitId(Guid.NewGuid()),
                ownerId,
                buildingNumber,
                apartmentNumber);

            newApartmentUnit.RaiseDomainEvent(new ApartmentUnitCreatedEvent(newApartmentUnit));

            return newApartmentUnit;
        }

        public void Update(string buildingNumber, string apartmentNumber)
        {
            BuildingNumber = buildingNumber;
            ApartmentNumber = apartmentNumber;
        }
    }
}
