using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;


namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public sealed class Customer 
        : Entity
    {


        #region Properties


        public string FirstName { get; set; }

        public string LastName { get; set; }


        public string FullName => $"{this.LastName}, {this.FirstName}";

        public string Telephone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }

        public Address Address { get; set; }

    
        /// <summary>
        /// Get or set if this customer is enabled
        /// </summary>
        public bool IsEnabled { get; private set; }


        /// <summary>
        /// Obtener o configurar identificador de país asociado
        /// </summary>
        public Guid CountryId { get; private set; }

        /// <summary>
        /// Obtén el país actual para este cliente.
        /// </summary>
        public Country Country { get; private set; }

        /// <summary>
        /// Obtener o configurar foto asociada para este cliente.
        /// </summary>

        public Picture Picture { get; private set; }

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
                this.IsEnabled = false;
        }

        /// <summary>
        /// Enable customer
        /// </summary>
        public void Enable()
        {
            if (!IsEnabled)
                this.IsEnabled = true;
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
            if (countryId == Guid.Empty) return;
            //fix relation
            this.CountryId = countryId;
            this.Country = null;
        }

        public void ChangePicture(Picture picture)
        {
            if (picture != null && !picture.IsTransient())
            {
                this.Picture = picture;
            }
        }

        #endregion

       
    }
}
