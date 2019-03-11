using InPort.Domain.AggregatesModel.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    class ProductMeasurentUnitConfiguration : IEntityTypeConfiguration<ProductMeasurentUnit>
    {
        public void Configure(EntityTypeBuilder<ProductMeasurentUnit> modelBuilder)
        {

            modelBuilder.HasKey(t => new { t.ProductId, t.MeasurentUnitId });

            modelBuilder.HasOne(pt => pt.Product)
                .WithMany(p => p.ProductMeasurentUnits)
                .HasForeignKey(pt => pt.ProductId);

            modelBuilder.HasOne(pt => pt.MeasurentUnit)
                .WithMany(t => t.ProductMeasurentUnits)
                .HasForeignKey(pt => pt.MeasurentUnitId);


        }
    }
}
