using Property.Domain.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Repositories
{
    public interface IApartmentUnitRepository
    {
        Task AddAsync(ApartmentUnit apartmentUnit);
        void DeleteAsync(ApartmentUnit apartmentUnit);
        Task<ApartmentUnit?> GetByIdAsync(ApartmentUnitId apartmentUnitId);
    }
}
