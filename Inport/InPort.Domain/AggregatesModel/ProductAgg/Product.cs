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
        public  ICollection<ProductMeasurentUnit> ProductMeasurentUnits { get; private set; }

        public  ICollection<OrderIncomeLine> OrderIncomeLines { get; private set; }

        #endregion

        #region Constructor
        public Product(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public Product()
        {
            ProductMeasurentUnits = new HashSet<ProductMeasurentUnit>();
            OrderIncomeLines = new HashSet<OrderIncomeLine>();
        }
        #endregion






    }
}
