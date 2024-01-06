using Common.Core.Domain;

namespace Streets.Persistence.Database.Models
{
    public class Street: EntityBaseGeneric<int>
    {
        public string Name { get; set; } = default!;
        public int Number { get; set; }
    }
}
