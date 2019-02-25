﻿using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public class Address : ValueObject<Address>
    {


        #region Properties


        public string City { get; private set; }


        public string ZipCode { get; private set; }


        public string AddressLine1 { get; private set; }


        public string AddressLine2 { get; private set; }

        #endregion

        #region Constructor


        public Address(string city, string zipCode, string addressLine1, string addressLine2)
        {
            this.City = city;
            this.ZipCode = zipCode;
            this.AddressLine1 = addressLine1;
            this.AddressLine2 = addressLine2;
        }

        private Address() { }  //required for EF

        #endregion
    }
}