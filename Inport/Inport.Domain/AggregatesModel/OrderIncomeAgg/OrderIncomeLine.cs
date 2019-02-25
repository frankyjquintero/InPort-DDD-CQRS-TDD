using InPort.Domain.AggregatesModel.ProductAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    public class OrderIncomeLine
        : Entity, IValidatableObject
    {
        #region Members
        //ILocalization messages;
        #endregion

        #region Properties


        /// <summary>
        /// Obtén o establece la cantidad de unidades en esta línea.
        /// </summary>
        public int Amount { get; set; }
        /// <summary>
        /// Relaciona la unidad de medida en esta línea con base a las elejibles para el producto.
        /// </summary>
        public string MeasurentUnit { get; private set; }

        /// <summary>
        /// Related aggregate identifier
        /// </summary>
        public Guid OrderId { get; set; }

        /// <summary>
        /// Get or set the product identifier
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Get or set associated product 
        /// </summary>
        public Product Product { get; private set; }

        #endregion

        #region Constructor
        public OrderIncomeLine()
        {
            //messages = LocalizationFactory.CreateLocalResources();
        }

        #endregion
        #region Public Methods


        public void SetProduct(Product product, string measurentUnit)
        {
            if (product == null
                ||
                product.IsTransient())
            {
                throw new ArgumentNullException("No puede establecer un producto nulo o transitorio");
            }
            //fix identifiers
            this.ProductId = product.Id;
            this.Product = product;
            this.MeasurentUnit = measurentUnit;
        }
  

        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            
            if (OrderId == Guid.Empty)
                validationResults.Add(new ValidationResult("El OrderId no puede ser nulo o vacio",
                                                           new string[] { "OrderId" }));

            

            if (ProductId == Guid.Empty)
                validationResults.Add(new ValidationResult("El productId no puede ser nulo o vacio",
                                                         new string[] { "ProductId" }));

            return validationResults;
        }

        #endregion
    }
}
