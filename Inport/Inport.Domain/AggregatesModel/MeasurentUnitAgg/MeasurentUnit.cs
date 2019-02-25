using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.MeasurentUnitAgg
{
    public class MeasurentUnit
        : Entity
    {
        #region Constructor
        public MeasurentUnit()
        {
        }

        public MeasurentUnit(string measurentUnitType, string measurentUnitDescription, string[] measurentUnitDetails)
        {
            MeasurentUnitType = measurentUnitType;
            MeasurentUnitDescription = measurentUnitDescription;
            MeasurentUnitDetails = measurentUnitDetails;
        }
        #endregion
        #region Properties


        public string MeasurentUnitType { get; private set; }

        public string MeasurentUnitDescription { get; private set; }

        public string[] MeasurentUnitDetails { get; private set; }

        #endregion
    }
}
