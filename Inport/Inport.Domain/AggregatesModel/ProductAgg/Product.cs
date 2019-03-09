using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.Core.Model;
using System.Collections.Generic;
using InPort.Domain.AggregatesModel.OrderIncomeAgg;

namespace InPort.Domain.AggregatesModel.ProductAgg
{
    public class Product
        : Entity
    {

        #region Properties

        public string Name { get; private set; }

        public string Description { get; private set; }

    
        public virtual ICollection<ProductMeasurentUnit> ProductMeasurentUnits { get; private set; }

        public virtual ICollection<OrderIncomeLine> OrderIncomeLines { get; private set; }

        public Product()
        {
            ProductMeasurentUnits = new HashSet<ProductMeasurentUnit>();
            OrderIncomeLines = new HashSet<OrderIncomeLine>();
        }
        #endregion




    }
}
