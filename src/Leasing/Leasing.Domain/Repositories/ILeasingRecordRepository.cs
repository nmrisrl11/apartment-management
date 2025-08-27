using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface ILeasingRecordRepository
    {
        Task AddAsync(LeasingRecord leasingRecord);
        Task<LeasingRecord?> GetByIdsAsync(LesseeId lesseeId, LessorId lessorId, ApartmentId apartmentId);
    }
}
