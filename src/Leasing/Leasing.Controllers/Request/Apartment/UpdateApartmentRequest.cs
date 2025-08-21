namespace Leasing.Controllers.Request.Apartment
{
    public class UpdateApartmentRequest
    {
        public required string BuildingNumber { get; set; } = null!;
        public required string ApartmentNumber { get; set; } = null!;
    }
}
