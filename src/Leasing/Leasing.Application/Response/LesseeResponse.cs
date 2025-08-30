namespace Leasing.Application.Response
{
    public class LesseeResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public List<LesseeLeasingRecordResponse> LeasingHistory { get; set; } = [];
    }

    public class LesseeSummaryResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
    }
}
