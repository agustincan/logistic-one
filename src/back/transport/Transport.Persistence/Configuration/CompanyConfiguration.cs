using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Transport.Domain.Models;

namespace Transport.Persistence
{
    internal class CompanyConfiguration
    {
        public CompanyConfiguration(EntityTypeBuilder<Company> entityBuilder)
        {
            //entityBuilder.ToTable("Transports");
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(2);
            entityBuilder.Property(x => x.Test).HasMaxLength(5);

            // Seed data
            entityBuilder.HasData(new List<Company>
            {
                new Company { Id = 1, Name = "A1", CreatedAt = new DateTime(2024, 6, 1), Test = 1 },
                new Company { Id = 2, Name = "B2", CreatedAt = new DateTime(2024, 6, 2), Test = 2 },
                new Company { Id = 3, Name = "C3", CreatedAt = new DateTime(2024, 6, 3), Test = 3 }
            });
        }
    }
}
