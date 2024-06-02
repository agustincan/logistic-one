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

            
        }
    }
}
