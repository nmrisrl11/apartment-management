using ApartmentManagement.SharedKernel.Entities;
using Property.Domain.ValueObjects;

namespace Property.Domain.Entities
{
    public class Owner : Entity
    {
        public OwnerId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        public static Owner Create(Guid id, string name)
        {
            return new Owner
            {
                Id = new OwnerId(id),
                Name = name
            };
        }
    }
}
