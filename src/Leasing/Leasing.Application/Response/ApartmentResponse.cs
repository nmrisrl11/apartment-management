using Leasing.Domain.Enums;

namespace Leasing.Application.Response
{
    public class ApartmentResponse
    {
        public Guid Id { get; set; }
        public required string BuildingNumber { get; set; }
        public required string ApartmentNumber { get; set; }
        public required ApartmentStatus Status { get; set; }
        public List<ApartmentLeasingRecordResponse> LeasingHistory { get; set; } = [];
    }
}
