using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Streets.Persistence.Database.Models;

namespace Streets.Persistence.Database.Configuration
{
    internal class StreetConfiguration
    {
        public StreetConfiguration(EntityTypeBuilder<Street> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
        }
    }
}