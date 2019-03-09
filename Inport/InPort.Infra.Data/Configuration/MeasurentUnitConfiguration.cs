using System;
using System.Collections.Generic;
using System.Text;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.ProductAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    class MeasurentUnitConfiguration : IEntityTypeConfiguration<MeasurentUnit>
    {
        public void Configure(EntityTypeBuilder<MeasurentUnit> builder)
        {
            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(o => o.Name).IsRequired();
            builder.HasOne<MeasurentUnitType>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("MeasurentUnitTypeId");
        }
    }
}
