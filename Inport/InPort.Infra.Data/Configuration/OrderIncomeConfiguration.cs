using System;
using System.Collections.Generic;
using System.Text;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    class OrderIncomeConfiguration : IEntityTypeConfiguration<OrderIncome>
    {
        public void Configure(EntityTypeBuilder<OrderIncome> builder)
        {
            //builder.ToTable("orderItems", OrderingContext.DEFAULT_SCHEMA);

            
            builder.Property(o => o.Id)
                .ValueGeneratedNever()
                .IsRequired();

            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.CustomerId).IsRequired();

        
            builder.HasOne<Customer>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("CustomerId");

            builder.HasOne<OrderIncomeStatus>()
                .WithMany()
                .IsRequired()
                .HasForeignKey("OrderIncomeStatusId");

        }
    }
}
