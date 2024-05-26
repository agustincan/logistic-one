using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streets.Persistence.Database.Models;

namespace Streets.Persistence.Database.Seeds
{
    internal class StreetSeed
    {
        public StreetSeed(EntityTypeBuilder<Street> entityBuilder)
        {
            var listSeeds = new List<Street>();
            for(int i = 1; i <= 7000; i++)
            {
                listSeeds.Add(new Street() { Id=i, Name = $"Street name {i}", Number = i*i+1 });
            }
            entityBuilder.HasData(listSeeds);
        }
    }
}
