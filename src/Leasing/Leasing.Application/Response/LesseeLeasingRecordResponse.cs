namespace Leasing.Application.Response
{
    public class LesseeLeasingRecordResponse
    {
        public Guid Id { get; set; }
        public ApartmentLeasedResponse Apartment { get; private set; } = null!;
        public DateTime DateCommenced { get; private set; }
        public DateTime DateExpiry { get; private set; }

    }

    public class ApartmentLeasedResponse
    {
        public Guid Id { get; set; }
        public Guid LessorId { get; set; }
        public LessorResponse Lessor { get; set; } = null!;
        public string BuildingNumber { get; set; } = string.Empty;
        public string ApartmentNumber { get; set; } = string.Empty;
    }
}
