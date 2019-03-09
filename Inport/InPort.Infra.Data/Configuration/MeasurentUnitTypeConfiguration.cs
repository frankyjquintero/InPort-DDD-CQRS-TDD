using System;
using System.Collections.Generic;
using System.Text;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    class MeasurentUnitTypeConfiguration : IEntityTypeConfiguration<MeasurentUnitType>
    {
        public void Configure(EntityTypeBuilder<MeasurentUnitType> builder)
        {
            builder.HasKey(o => o.Id);

            builder.Property(o => o.Id)
                .HasDefaultValue(1)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
