using System;
using Logistic.Persistence.Transport.Configuration;
using Microsoft.EntityFrameworkCore;
using Transport.Domain.Models;

namespace Logistic.Persistence.Transport
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Transport> Transports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.HasDefaultSchema("Transport");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new TransportConfiguration(modelBuilder.Entity<Transport>());
        }
    }
}
