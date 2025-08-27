using Leasing.Domain.ValueObjects;

namespace Leasing.Domain.Entities
{
    public class Lessor
    {
        public LessorId Id { get; private set; } = null!;
        public string Name { get; private set; } = null!;

        public static Lessor Create(Guid id, string name)
        {
            return new Lessor
            {
                Id = new LessorId(id),
                Name = name
            };
        }
    }
}
