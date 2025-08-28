using Property.Domain.Enums;

namespace Property.Application.Response
{
    public class ApartmentUnitResponse
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; }
        public OwnerResponse Owner { get; set; } = null!;
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public ApartmentUnitStatus Status { get; private set; }
    }
}
