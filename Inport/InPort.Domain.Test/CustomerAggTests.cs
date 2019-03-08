using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.AggregatesModel.CustomerAgg;
using Xunit;

namespace InPort.Domain.Test
{
    public class CustomerAggTests
    {

        [Fact]
        public void CustomerCannotAssociateTransientCountry()
        {
            //Arrange
            var country = new Country("Spain", "es-ES");

            //Act
            var customer = new Customer();
            Exception ex = Assert.Throws<ArgumentException>(() => customer.SetTheCountryForThisCustomer(country));
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void CustomerCannotAssociateNullCountry()
        {
            //Arrange
            var country = new Country("Spain", "es-ES");

            //Act
            var customer = new Customer();
            Exception ex = Assert.Throws<ArgumentException>(() => customer.SetTheCountryForThisCustomer(null));
            Assert.IsType<ArgumentException>(ex);
        }
        [Fact]
        public void CustomerSetCountryFixCountryId()
        {
            //Arrange
            var country = new Country("Spain", "es-ES");
            country.GenerateNewIdentity();

            //Act
            var customer = new Customer();
            customer.SetTheCountryForThisCustomer(country);

            //Assert
            Assert.Equal(country.Id, customer.CountryId);
        }
        [Fact]
        public void CustomerDisableSetIsEnabledToFalse()
        {
            //Arrange 
            var customer = new Customer();

            //Act
            customer.Disable();

            //assert
            Assert.False(customer.IsEnabled);
        }
        [Fact]
        public void CustomerEnableSetIsEnabledToTrue()
        {
            //Arrange 
            var customer = new Customer();

            //Act
            customer.Enable();

            //assert
            Assert.True(customer.IsEnabled);
        }
        [Fact]
        public void CustomerFactoryWithCountryEntityCreateValidCustomer()
        {
            //Arrange
            var lastName = "El rojo";
            var firstName = "Jhon";
            var telephone = "+34111111";
            var company = "company name";

            var country = new Country("Spain", "es-ES");
            country.GenerateNewIdentity();

            //Act
            var customer = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));
           

            //Assert
            Assert.Equal(customer.LastName, lastName);
            Assert.Equal(customer.FirstName, firstName);
            Assert.Equal(customer.Country, country);
            Assert.Equal(customer.CountryId, country.Id);
            Assert.True(customer.IsEnabled);
            Assert.Equal(customer.Company, company);
            Assert.Equal(customer.Telephone, telephone);
        }
        [Fact]
        public void CustomerFactoryWithCountryIdEntityCreateValidCustomer()
        {
            //Arrange
            var lastName = "El rojo";
            var firstName = "Jhon";
            var telephone = "+34111111";
            var company = "company name";


            var country = new Country("Spain", "es-ES");
            country.GenerateNewIdentity();

            //Act
            var customer = CustomerFactory.CreateCustomer(firstName, lastName, telephone, company, "email@email.com", country, new Address("city", "zipcode", "AddressLine1", "AddressLine2"));


            //Assert
            Assert.Equal(customer.LastName, lastName);
            Assert.Equal(customer.FirstName, firstName);
            Assert.Equal(customer.CountryId, country.Id);
            Assert.True(customer.IsEnabled);
            Assert.Equal(customer.Company, company);
            Assert.Equal(customer.Telephone, telephone);

      
        }
    }
}
