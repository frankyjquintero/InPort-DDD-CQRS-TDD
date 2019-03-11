using InPort.Domain.Core.Model;
using System.Collections.Generic;
using InPort.Domain.AggregatesModel.ProductAgg;

namespace InPort.Domain.AggregatesModel.MeasurentUnitAgg
{
    public class MeasurentUnit
        : Entity
    {
       
        #region Properties
        public MeasurentUnitType MeasurentUnitType { get; private set; }
        public int MeasurentUnitTypeId { get; private set; }

        public string Name { get; private set; }

        public virtual ICollection<ProductMeasurentUnit> ProductMeasurentUnits { get; private set; }
        #endregion

        #region Constructor
        public MeasurentUnit()
        {
            ProductMeasurentUnits = new HashSet<ProductMeasurentUnit>();
        }

        public MeasurentUnit(MeasurentUnitType measurentUnitType, string name)
        {
            Name = name;
            MeasurentUnitType = measurentUnitType;
            MeasurentUnitTypeId = measurentUnitType.Id;
        }
        #endregion
    }
}
