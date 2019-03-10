using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
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
        public int OrderIncomeStatusId { get; private set; }

        public ICollection<OrderIncomeLine> OrderIncomeLines { get; private set; }
        #endregion

        #region Constructor
        public OrderIncome()
        {
            OrderIncomeLines = new HashSet<OrderIncomeLine>();
        }

        public OrderIncome(string mainSupportDocument, string secondarySupportDocument, string observation)
        {
            MainSupportDocument = mainSupportDocument;
            SecondarySupportDocument = secondarySupportDocument;
            Observation = observation;
            //SequenceNumberOrder = sequenceNumberOrder;
            OrderDate = DateTime.Now;
            OrderIncomeStatusId = OrderIncomeStatus.Ingreso.Id;
            OrderIncomeStatus = OrderIncomeStatus.Ingreso;
            OrderIncomeLines = new HashSet<OrderIncomeLine>();
        }
        #endregion

        #region Public Methods

        public void SetRegistroBitacoraStatus()
        {
            if (OrderIncomeStatusId == OrderIncomeStatus.Ingreso.Id) OrderIncomeStatusId = OrderIncomeStatus.RegistroBitacora.Id;
            else
            {
                throw new Exception("La orden debe estar en estado: " + OrderIncomeStatus.Ingreso);
            }
        }
        public void SetDianStatus()
        {
            if (OrderIncomeStatusId == OrderIncomeStatus.RegistroBitacora.Id) OrderIncomeStatusId = OrderIncomeStatus.Dian.Id;
            else
            {
                throw new Exception("La orden debe estar en estado: " + OrderIncomeStatus.RegistroBitacora);
            }
        }
        public void SetVerificacionBitacoraStatus()
        {
            if (OrderIncomeStatusId == OrderIncomeStatus.Dian.Id) OrderIncomeStatusId = OrderIncomeStatus.VerificacionBitacora.Id;
            else
            {
                throw new Exception("La orden debe estar en estado: " + OrderIncomeStatus.Dian);
            }
        }
        public void SetCompletadoStatus()
        {
            if (OrderIncomeStatusId == OrderIncomeStatus.VerificacionBitacora.Id) OrderIncomeStatusId = OrderIncomeStatus.Completado.Id;
            else
            {
                throw new Exception("La orden debe estar en estado: " + OrderIncomeStatus.VerificacionBitacora);
            }
        }
        public void SetTheCustomerForThisOrder(Customer customer)
        {
            if (customer == null
                ||
                customer.IsTransient())
            {
                throw new ArgumentException("No puede asociar un cliente nulo o transendente");
            }

            Customer = customer;
            CustomerId = customer.Id;
        }
        public void SetTheCustomerReferenceForThisOrder(Guid customerId)
        {
            if (customerId == Guid.Empty) throw new ArgumentException("No puede asociar un cliente nulo o transendente"); 
            this.Customer = null;
            this.CustomerId = customerId;
        }
        public void AddOrderItem(Product product, MeasurentUnit measurentUnit, int units = 1)
        {
            var existingOrderForProduct = OrderIncomeLines
                .SingleOrDefault(o => (o.ProductId == product.Id && o.MeasurentUnitId == measurentUnit.Id));

            if (existingOrderForProduct != null)
            {
                existingOrderForProduct.AddAmount(units);
            }
            else
            {
                var orderItem = new OrderIncomeLine(Id,product, measurentUnit, units);
                OrderIncomeLines.Add(orderItem);
            }
        }


        #endregion

    }
}
