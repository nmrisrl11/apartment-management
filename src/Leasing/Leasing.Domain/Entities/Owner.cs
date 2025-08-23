using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Owner
    {
        public OwnerId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;


        protected Owner() { }

        public static Owner Create(string name)
        {
            return new Owner
            {
                Id = new OwnerId(Guid.NewGuid()),
                Name = name
            };
        }

        public void Update(string name)
        {
            Name = name;
        }
    }
}
