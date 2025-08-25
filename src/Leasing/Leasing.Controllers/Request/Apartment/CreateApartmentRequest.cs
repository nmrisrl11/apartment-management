namespace Leasing.Controllers.Request.Apartment
{
    public class CreateApartmentRequest
    {
        public Guid OwnerId { get; set; }
        public required string BuildingNumber { get; set; } = string.Empty;
        public required string ApartmentNumber { get; set; } = string.Empty;
    }
}
