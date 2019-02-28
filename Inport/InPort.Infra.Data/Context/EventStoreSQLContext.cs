using System;
using System.IO;
using InPort.Domain.Core.Events;
using InPort.Infra.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace InPort.Infra.Data.Context
{
    public class EventStoreSQLContext : DbContext
    {
        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventConfiguration());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {   
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            Console.WriteLine("kheeeeeeeeeeeeeeeeeee" + config.GetConnectionString("EventSourcingDatabase"));
            optionsBuilder.UseSqlServer(config.GetConnectionString("EventSourcingDatabase"));
        }
    }
}