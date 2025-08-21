namespace Leasing.Controllers.Request.Apartment
{
    public class CreateApartmentRequest
    {
        public required string BuildingNumber { get; set; } = null!;
        public required string ApartmentNumber { get; set; } = null!;
    }
}
