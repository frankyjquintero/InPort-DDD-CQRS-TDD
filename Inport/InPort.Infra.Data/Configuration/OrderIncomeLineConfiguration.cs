using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InPort.Infra.Data.Configuration
{
    internal class OrderIncomeLineConfiguration : IEntityTypeConfiguration<OrderIncomeLine>
    {
        public void Configure(EntityTypeBuilder<OrderIncomeLine> builder)
        {
            //builder.ToTable("orderItems", OrderingContext.DEFAULT_SCHEMA);

            builder.Property(e => e.Id)
                .HasColumnName("OrderIncomeLineId")
                .ValueGeneratedNever();
            builder.Property<Guid>("OrderIncomeId")
                .IsRequired();
            builder.Property<Guid>("ProductId")
                .IsRequired();
            builder.Property<string>("ProductName")
                .IsRequired();
            builder.Property<Guid>("MeasurentUnitId")
                .IsRequired();
            builder.Property<string>("MeasurentUnitName")
                .IsRequired();
            builder.Property<int>("Amount")
                            .IsRequired();

        }
    }
}
