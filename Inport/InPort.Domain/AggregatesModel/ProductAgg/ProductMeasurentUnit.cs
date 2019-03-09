using System;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;

namespace InPort.Domain.AggregatesModel.ProductAgg
{
    public class ProductMeasurentUnit
    {
        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid MeasurentUnitId { get; set; }
        public MeasurentUnit MeasurentUnit { get; set; }
    }
}
