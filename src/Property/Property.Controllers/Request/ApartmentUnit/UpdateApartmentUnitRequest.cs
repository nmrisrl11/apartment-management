namespace Property.Controllers.Request.ApartmentUnit
{
    public class UpdateApartmentUnitRequest
    {
        public required string BuildingNumber { get; set; } = string.Empty;
        public required string ApartmentNumber { get; set; } = string.Empty;
    }
}
