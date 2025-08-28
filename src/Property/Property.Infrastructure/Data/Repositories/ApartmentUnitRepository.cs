using Property.Domain.Entities;
using Property.Domain.Repositories;
using Property.Domain.ValueObjects;

namespace Property.Infrastructure.Data.Repositories
{
    public class ApartmentUnitRepository : IApartmentUnitRepository
    {
        private readonly PropertyDbContext _context;

        public ApartmentUnitRepository(PropertyDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ApartmentUnit apartmentUnit)
        {
            await _context.ApartmentUnits.AddAsync(apartmentUnit);
        }

        public void DeleteAsync(ApartmentUnit apartmentUnit)
        {
            _context.ApartmentUnits.Remove(apartmentUnit);
        }

        public async Task<ApartmentUnit?> GetByIdAsync(ApartmentUnitId apartmentUnitId)
        {
            return await _context.ApartmentUnits.FindAsync(apartmentUnitId);
        }
    }
}
