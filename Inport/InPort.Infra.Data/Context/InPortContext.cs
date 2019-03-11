using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using InPort.Domain.AggregatesModel.ProductAgg;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<Product> Products { get; set; }
        public DbSet<MeasurentUnit> MeasurentUnits { get; set; }
        public DbSet<OrderIncome> OrderIncomes { get; set; }
        public DbSet<OrderIncomeLine> OrderIncomeLines { get; set; }
        public DbSet<OrderIncomeStatus> OrderStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InPortDbContext).Assembly);         
        }
    }
}
