using Leasing.Domain.Entities;
using Leasing.Domain.Repositories;
using Leasing.Domain.ValueObjects;

namespace Leasing.Infrastructure.Data.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly LeasingDbContext _context;

        public ApartmentRepository(LeasingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Apartment apartment)
        {
            await _context.Apartments.AddAsync(apartment);
        }

        public void DeleteAsync(Apartment apartment)
        {
            _context.Apartments.Remove(apartment);
        }

        public async Task<Apartment?> GetByIdAsync(ApartmentId apartmentId)
        {
            return await _context.Apartments.FindAsync(apartmentId);
        }
    }
}
