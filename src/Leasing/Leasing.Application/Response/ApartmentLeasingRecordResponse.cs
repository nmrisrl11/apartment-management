namespace Leasing.Application.Response
{
    public class ApartmentLeasingRecordResponse
    {
        public Guid Id { get; set; }
        public ApartmentLesseeResponse Lessee { get; set; } = null!;
        public DateTime DateCommenced { get; set; }
        public DateTime DateExpiry { get; set; }
    }

    public class ApartmentLesseeResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
