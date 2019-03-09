using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.AggregatesModel.ProductAgg;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{

    public class OrderIncome
        : Entity
    {
        #region Properties

        public DateTime OrderDate { get; private set; }
        public string MainSupportDocument { get; private set; }
        public string SecondarySupportDocument { get; private set; }
        public string Observation { get; set; }

        public Guid CustomerId { get; private set; }
        public virtual Customer Customer { get; private set; }
        public OrderIncomeStatus OrderIncomeStatus { get; private set; }
        private int _orderStatusId;

        public ICollection<OrderIncomeLine> OrderIncomeLines { get; private set; }
        #endregion

        #region Constructor
        public OrderIncome()
        {
            OrderIncomeLines = new HashSet<OrderIncomeLine>();
        }

        public OrderIncome(string mainSupportDocument, string secondarySupportDocument, string observation, int sequenceNumberOrder, Guid customerId)
        {
            MainSupportDocument = mainSupportDocument;
            SecondarySupportDocument = secondarySupportDocument;
            Observation = observation;
            //SequenceNumberOrder = sequenceNumberOrder;
            CustomerId = customerId;
            OrderDate = DateTime.Now;
            _orderStatusId = OrderIncomeStatus.Ingreso.Id;
        }
        #endregion

        #region Public Methods

        public void SetRegistroBitacoraStatus()
        {
            if (_orderStatusId == OrderIncomeStatus.Ingreso.Id) _orderStatusId = OrderIncomeStatus.RegistroBitacora.Id;
        }
        public void SetDianStatus()
        {
            if (_orderStatusId == OrderIncomeStatus.RegistroBitacora.Id) _orderStatusId = OrderIncomeStatus.Dian.Id;
        }
        public void SetVerificacionBitacoraStatus()
        {
            if (_orderStatusId == OrderIncomeStatus.Dian.Id) _orderStatusId = OrderIncomeStatus.VerificacionBitacora.Id;
        }
        public void SetCompletadoStatus()
        {
            if (_orderStatusId == OrderIncomeStatus.VerificacionBitacora.Id) _orderStatusId = OrderIncomeStatus.Completado.Id;
        }
        public void SetTheCustomerForThisOrder(Customer customer)
        {
            if (customer == null
                ||
                customer.IsTransient())
            {
                throw new ArgumentException("No puede asociar un cliente nulo o transendente");
            }

            this.Customer = customer;
            this.CustomerId = customer.Id;
        }
        public void SetTheCustomerReferenceForThisOrder(Guid customerId)
        {
            if (customerId == Guid.Empty) return;
            this.Customer = null;
            this.CustomerId = customerId;
        }
        public void AddOrderItem(Product product, MeasurentUnit measurentUnit, int units = 1)
        {
            //var existingOrderForProduct = OrderIncomeLines
            //    .SingleOrDefault(o => (o.ProductId == product.Id && o.MeasurentUnitName == measurentUnit.Name ));

            //if (existingOrderForProduct != null)
            //{
            //    existingOrderForProduct.AddAmount(units);
            //}
            //else
            //{
            //    var orderItem = new OrderIncomeLine(product, measurentUnit, units);
            //    _orderIncomeLines.Add(orderItem);
            //}
        }


        #endregion

    }
}
