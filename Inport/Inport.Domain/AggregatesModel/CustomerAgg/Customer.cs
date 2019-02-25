using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public class Customer 
        : Entity, IValidatableObject
    {
        #region Members

        bool _IsEnabled;
        #endregion

        #region Properties


        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string FullName
        {
            get
            {
                return string.Format("{0}, {1}", this.LastName, this.FirstName);
            }

        }

        public string Telephone { get; set; }
        public string Company { get; set; }

        public virtual Address Address { get; set; }

    
        /// <summary>
        /// Get or set if this customer is enabled
        /// </summary>
        public bool IsEnabled
        {
            get
            {
                return _IsEnabled;
            }
            private set
            {
                _IsEnabled = value;
            }
        }


        /// <summary>
        /// Obtener o configurar identificador de país asociado
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Obtén el país actual para este cliente.
        /// </summary>
        public virtual Country Country { get; private set; }

        /// <summary>
        /// Obtener o configurar foto asociada para este cliente.
        /// </summary>
        public virtual Picture Picture { get; private set; }

        #endregion

        #region Constructor
        public Customer()
        {
        }
        #endregion
        #region Public Methods

        /// <summary>
        /// Disable customer
        /// </summary>
        public void Disable()
        {
            if (IsEnabled)
                this._IsEnabled = false;
        }

        /// <summary>
        /// Enable customer
        /// </summary>
        public void Enable()
        {
            if (!IsEnabled)
                this._IsEnabled = true;
        }

        /// <summary>
        /// Asociar país existente a este cliente.
        /// </summary>
        /// <param name="country"></param>
        public void SetTheCountryForThisCustomer(Country country)
        {
            if (country == null
                ||
                country.IsTransient())
            {
                throw new ArgumentException("No puede asociar un pais nulo o transitorio");
            }

            //fix relation
            this.CountryId = country.Id;

            this.Country = country;
        }

        /// <summary>
        /// Establecer la referencia del país para este cliente.
        /// </summary>
        /// <param name="countryId"></param>
        public void SetTheCountryReference(Guid countryId)
        {
            if (countryId != Guid.Empty)
            {
                //fix relation
                this.CountryId = countryId;

                this.Country = null;
            }
        }

        public void ChangePicture(Picture picture)
        {
            if (picture != null &&
                !picture.IsTransient())
            {
                this.Picture = picture;
            }
        }

        #endregion

        #region IValidatableObject Members

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

        
            if (String.IsNullOrWhiteSpace(this.FirstName))
            {
                validationResults.Add(new ValidationResult("Primer Nombre no puede ser vacio o nulo",
                                                           new string[] { "FirstName" }));
            }

            if (String.IsNullOrWhiteSpace(this.LastName))
            {
                validationResults.Add(new ValidationResult("segundo Nombre no puede ser vacio o nulo",
                                                           new string[] { "LastName" }));
            }

            //-->Check Country identifier
            if (this.CountryId == Guid.Empty)
                validationResults.Add(new ValidationResult("El identificar de pais no puede ser vacio o nulo",
                                                          new string[] { "CountryId" }));


            return validationResults;
        }

        #endregion
    }
}
