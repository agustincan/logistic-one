using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Transport.Domain.Models;

namespace Transport.Persistence
{
    internal class TransportConfiguration
    {
        public TransportConfiguration(EntityTypeBuilder<Transportt> entityBuilder)
        {
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            var random = new Random();
            var products = new List<Transportt>();

            for (var i = 1; i <= 10; i++)
            {
                products.Add(new Transportt
                {
                    Id = i,
                    Description = $"Description for transport {i}",
                });
            }

            entityBuilder.HasData(products);
        }
    }
}
