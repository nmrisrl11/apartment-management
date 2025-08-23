namespace Leasing.Application.Response
{
    public class TenantResponse
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string ContactNumber { get; set; }
        public List<TenantLeasingRecordResponse> LeasingHistory { get; set; } = [];
    }
}
