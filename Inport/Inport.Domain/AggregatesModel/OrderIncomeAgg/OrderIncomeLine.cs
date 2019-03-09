using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.ProductAgg;
using InPort.Domain.Core.Model;
using System;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    public class OrderIncomeLine
        : Entity
    {


        #region Properties

        public Guid OrderIncomeId { get; private set; }
        public Guid ProductId { get; private set; }
        public string ProductName { get; private set; }

        public Guid MeasurentUnitId { get; private set; }
        public string MeasurentUnitName { get; private set; }

        public int Amount { get; private set; }

        public OrderIncome OrderIncome { get; set; }
        public Product Product { get; set; }
        public MeasurentUnit MeasurentUnit { get; set; }

        #endregion

        #region Constructor
        public OrderIncomeLine()
        {

        }
        public OrderIncomeLine(Guid orderIncomeId, Product product, MeasurentUnit measurentUnit, int amount)
        {
            if (product == null || product.IsTransient())
            {
                throw new ArgumentNullException(nameof(product));
            }
            if (measurentUnit == null || measurentUnit.IsTransient())
            {
                throw new ArgumentNullException(nameof(measurentUnit));
            }

            OrderIncomeId = orderIncomeId;
            ProductId = product.Id;
            ProductName = product.Name;
            MeasurentUnitId = measurentUnit.Id;
            MeasurentUnitName = measurentUnit.Name;
            Amount = amount;
        }
        #endregion
        #region Public Methods

        public void SetAmount(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Invalid amount");
            }
            Amount = amount;
        }
        public void AddAmount(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Invalid amount");
            }
            Amount += amount;
        }



        #endregion


    }
}
