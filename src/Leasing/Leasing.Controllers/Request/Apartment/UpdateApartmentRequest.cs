namespace Leasing.Controllers.Request.Apartment
{
    public class UpdateApartmentRequest
    {
        public required string BuildingNumber { get; set; } = string.Empty;
        public required string ApartmentNumber { get; set; } = string.Empty;
    }
}
