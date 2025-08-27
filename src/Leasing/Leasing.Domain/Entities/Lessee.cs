using ApartmentManagement.SharedKernel.Entities;
using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Lessee : Entity
    {
        public LesseeId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;
        public string Email { get; private set; } = null!;
        public string ContactNumber { get; private set; } = null!;
        public List<LeasingRecord> LeasingHistory { get; set; } = [];

        public static Lessee Create(Guid id, string name, string email, string contactNumber)
        {
           return new Lessee
           {
               Id = new LesseeId(id),
               Name = name,
               Email = email,
               ContactNumber = contactNumber
           };
        }
    }
}
