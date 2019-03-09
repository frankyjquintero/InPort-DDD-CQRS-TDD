using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InPort.Infra.Data.Configuration
{
    internal class OrderIncomeStatusConfiguration : IEntityTypeConfiguration<OrderIncomeStatus>
    {
        public void Configure(EntityTypeBuilder<OrderIncomeStatus> builder)
        {
            //builder.ToTable("orderstatus", InPort.DEFAULT_SCHEMA);

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
