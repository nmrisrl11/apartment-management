using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

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

        public async Task<LeasingRecord?> GetByIdsAsync(LesseeId lesseeId, LessorId lessorId, ApartmentId apartmentId)
        {
            return await _context.LeasingRecords
                .Where(lr => lr.LesseeId == lesseeId && lr.LessorId == lessorId && lr.ApartmentId == apartmentId)
                .Include(lr => lr.Lessee)
                .Include(lr => lr.Lessor)
                .Include(lr => lr.Apartment)
                .FirstOrDefaultAsync();
        }
    }
}
