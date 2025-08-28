namespace Property.Controllers.Request.ApartmentUnit
{
    public class CreateApartmentUnitRequest
    {
        public Guid OwnerId { get; set; }
        public required string BuildingNumber { get; set; } = string.Empty;
        public required string ApartmentNumber { get; set; } = string.Empty;
    }
}
