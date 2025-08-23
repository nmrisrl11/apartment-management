namespace Leasing.Application.Response
{
    public class ApartmentLeasingRecordResponse
    {
        public Guid Id { get; set; }
        public ApartmentLesseeResponse Lessee { get; set; } = null!;
        public DateTime DateLeased { get; set; }
        public DateTime DateRenewal { get; set; }
    }

    public class ApartmentLesseeResponse
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
    }
}
