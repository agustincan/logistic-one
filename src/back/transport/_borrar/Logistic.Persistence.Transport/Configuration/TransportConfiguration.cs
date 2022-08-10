using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logistic.Persistence.Transport.Configuration
{
    internal class TransportConfiguration
    {
        public TransportConfiguration(EntityTypeBuilder<Transport> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            var random = new Random();
            var products = new List<Transport>();

            for (var i = 1; i <= 10; i++)
            {
                products.Add(new Transport
                {
                    Id = i,
                    Description = $"Description for transport {i}",
                });
            }

            entityBuilder.HasData(products);
        }
    }
}
