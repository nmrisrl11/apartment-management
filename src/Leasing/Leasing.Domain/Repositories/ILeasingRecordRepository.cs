using Leasing.Domain.Entities;

namespace Leasing.Domain.Repositories
{
    public interface ILeasingRecordRepository
    {
        Task AddAsync(LeasingRecord leasingRecord);
    }
}
