using ApartmentManagement.SharedKernel.Entities;
using Ownership.Domain.DomainEvents;
using Ownership.Domain.ValueObjects;

namespace Ownership.Domain.Entities
{
    public class Owner : Entity
    {
        public OwnerId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        private Owner() { }

        private Owner(OwnerId ownerId, string name)
        {
            Id = ownerId;
            Name = name;
        }

        public static Owner Create(string name)
        {
            var newOwner = new Owner(new OwnerId(Guid.NewGuid()), name);

            newOwner.RaiseDomainEvent(new OwnerCreatedEvent(newOwner));

            return newOwner;
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
