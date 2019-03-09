using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {

            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(o => o.Name).IsRequired();
            builder.Property(e => e.Description).IsRequired();


        }
    }
}
