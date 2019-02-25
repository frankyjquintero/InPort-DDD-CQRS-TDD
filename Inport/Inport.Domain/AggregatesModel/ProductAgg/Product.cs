using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InPort.Domain.AggregatesModel.ProductAgg
{
    public class Product
        : Entity, IValidatableObject
    {

        #region Properties

        public string Name { get; protected set; }

        public string Description { get; protected set; }

        /// <summary>
        /// Obtener o configurar identificador de unidad de medidas asociado
        /// </summary>
        public Guid MeasurentUnitId { get; private set; }

        /// <summary>
        /// Obtén las unidades de medidas para este producto.
        /// </summary>
        public virtual MeasurentUnit MeasurentUnit { get; private set; }

        #endregion

        #region Public Methods



        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //ILocalization messages = LocalizationFactory.CreateLocalResources();

            var validationResults = new List<ValidationResult>();     

            if (MeasurentUnit == null)
                validationResults.Add(new ValidationResult("El tipo de unidad de medida no puede ser nula", new string[] { "MeasurentUnit" }));

            return validationResults;
        }

        #endregion  
    }
}
