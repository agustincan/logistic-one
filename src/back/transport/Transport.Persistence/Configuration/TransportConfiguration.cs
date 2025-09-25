using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using Transport.Domain.Models;
using Common.Core.Domain;

namespace Transport.Persistence
{
    internal class TransportConfiguration
    {
        public TransportConfiguration(EntityTypeBuilder<Transportt> entityBuilder)
        {
            //entityBuilder.ToTable("Transports");
            entityBuilder.HasIndex(x => x.Id);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(200);

            // Seed data
            entityBuilder.HasData(new List<Transportt>
            {
                new Transportt { Id = 1, Description = "Transport 1", License = "ABC123", Type = TransportType.Car, StatusMode = TransportMode.Created, Status = StatusType.Enabled, Active = true },
                new Transportt { Id = 2, Description = "Transport 2", License = "DEF456", Type = TransportType.Truck, StatusMode = TransportMode.Operative, Status = StatusType.Enabled, Active = true },
                new Transportt { Id = 3, Description = "Transport 3", License = "GHI789", Type = TransportType.Bus, StatusMode = TransportMode.InDeposit, Status = StatusType.Disabled, Active = false }
            });
        }
    }
}
