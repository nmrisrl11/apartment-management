using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class LeasingRecordRepository : ILeasingRecordRepository
    {
        private readonly LeasingDbContext _context;

        public LeasingRecordRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(LeasingRecord leasingRecord)
        {
            await _context.LeasingRecords.AddAsync(leasingRecord);
        }
    }
}
