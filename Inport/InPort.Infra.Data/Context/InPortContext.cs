using System.IO;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace InPort.Infra.Data.Context
{
    public class InPortDbContext : DbContext
    {
        public InPortDbContext(DbContextOptions<InPortDbContext> options)
             : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InPortDbContext).Assembly);
        }
    }
}
