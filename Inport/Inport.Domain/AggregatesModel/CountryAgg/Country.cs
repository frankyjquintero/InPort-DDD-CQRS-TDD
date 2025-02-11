﻿
using InPort.Domain.Core.Model;
using System;

namespace InPort.Domain.AggregatesModel.CountryAgg
{
    public class Country
        : Entity
    {
        #region Properties


        public string CountryName { get; private set; }

        public string CountryISOCode { get; private set; }

        #endregion

        #region Constructor

        //requerido por EF
        public Country() { }

        public Country(string countryName, string countryISOCode)
        {
            if (String.IsNullOrWhiteSpace(countryName))
                throw new ArgumentNullException("countryName");

            if (String.IsNullOrWhiteSpace(countryISOCode))
                throw new ArgumentNullException("countryISOCode");

            this.CountryName = countryName;
            this.CountryISOCode = countryISOCode;
        }

        #endregion

        public void SetName(string name)
        {
            CountryName = name;
        }
        public void SetIsoCode(string isoCode)
        {
            CountryISOCode = isoCode;
        }
    }
}
