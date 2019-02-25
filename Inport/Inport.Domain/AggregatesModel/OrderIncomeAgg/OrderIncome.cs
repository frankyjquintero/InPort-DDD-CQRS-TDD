using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    public class OrderIncome
        :Entity,IValidatableObject
    {
        #region Members

        HashSet<OrderIncomeLine> _Lines;
        //ILocalization messages;

        #endregion

        #region Properties

        /// <summary>
        /// Obtén o establece la fecha de la orden de entrada
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Obtén o establece un documento de soporte principal
        /// </summary>
        public string MainSupportDocument { get; set; }
        /// <summary>
        /// Obtén o establece un documento de soporte segundario
        /// </summary>
        public string SecondarySupportDocument { get; set; }

        /// <summary>
        /// Obtén o establece una observacion para la orden de entrada
        /// </summary>
        public string Observation { get; set; }
        

        /// <summary>
        /// Obtener el orden de los números de secuencia de estaorden de ingreso
        /// </summary>
        public int SequenceNumberOrder { get; private set; }

        /// <summary>
        /// Consigue un número de orden de iingreso amigable
        /// </summary>
        public string OrderNumber
        {
            get
            {
                return string.Format("{0}/{1}-{2}", OrderDate.Year, OrderDate.Month, SequenceNumberOrder);
            }
        }
        /// <summary>
        /// Identificador de cliente asociado a esta Orden de ingreso
        /// </summary>
        public Guid CustomerId { get; private set; }
        /// <summary>
        /// Get the related customer
        /// </summary>
        public virtual Customer Customer { get; private set; }



        /// <summary>
        /// Obtener o establecer líneas de orden relacionadas
        /// </summary>
        public virtual ICollection<OrderIncomeLine> OrderIncomeLines
        {
            get
            {
                if (_Lines == null)
                    _Lines = new HashSet<OrderIncomeLine>();

                return _Lines;
            }
            set
            {
                _Lines = new HashSet<OrderIncomeLine>(value);
            }
        }

        #endregion

        #region Constructor
        public OrderIncome()
        {
            //messages = LocalizationFactory.CreateLocalResources();
        }
        #endregion

        #region Public Methods


        /// <summary>
        /// Link a customer to this order line
        /// </summary>
        /// <param name="customer">The customer to relate</param>
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

        /// <summary>
        /// Establecer la referencia del cliente para esta orden de ingreso.
        /// </summary>
        /// <param name="customerId">the customer identifier</param>
        public void SetTheCustomerReferenceForThisOrder(Guid customerId)
        {
            if (customerId != Guid.Empty)
            {
                this.Customer = null;
                this.CustomerId = customerId;
            }
        }



        #endregion

        #region IValidatableObject Members
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();


            if (CustomerId == Guid.Empty)
                validationResults.Add(new ValidationResult("El cliente no puede ser nulo",
                                                            new string[] { "CustomerId" }));

            return validationResults;
        }

        #endregion
    }
}
