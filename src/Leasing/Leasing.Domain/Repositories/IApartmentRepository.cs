using Leasing.Domain.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Repositories
{
    public interface IApartmentRepository
    {
        Task AddAsync(Apartment apartment);
        Task<Apartment?> GetByIdAsync(ApartmentId apartmentId);
    }
}
