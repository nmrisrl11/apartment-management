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

        public async Task<LeasingRecord?> GetByIdsAsync(TenantId tenantId, OwnerId ownerId, ApartmentId apartmentId)
        {
            return await _context.LeasingRecords
                .Where(lr => lr.TenantId == tenantId && lr.OwnerId == ownerId && lr.ApartmentId == apartmentId)
                .Include(lr => lr.Tenant)
                .Include(lr => lr.Owner)
                .Include(lr => lr.Apartment)
                .FirstOrDefaultAsync();
        }
    }
}
