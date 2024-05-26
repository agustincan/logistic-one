using Common.Core.Domain;

namespace Streets.Persistence.Database.Models
{
    public class StreetCopy: EntityBaseGeneric<int>
    {
        public int StreetId { get; set; }
        public string Name { get; set; } = default!;
        public int Number { get; set; }
    }
}
