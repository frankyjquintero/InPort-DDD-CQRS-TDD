using InPort.Domain.AggregatesModel.CountryAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    /// <summary>
    /// Esta es la fábrica para la creación del Cliente, lo que significa que el 
    /// propósito principal
    /// es encapsular el conocimiento de la creación.
    /// Lo que se crea es una instancia de entidad transitoria, aún no se ha dicho nada sobre la persistencia
    /// </summary>
    public static class CustomerFactory
    {

        public static Customer CreateCustomer(string firstName, string lastName, string telephone, string company, Country country, Address address)
        {
            //crear nueva instancia y establecer identidad
            var customer = new Customer();

            customer.GenerateNewIdentity();

            //establecer datos

            customer.FirstName = firstName;
            customer.LastName = lastName;

            customer.Company = company;
            customer.Telephone = telephone;

            //establecer direccion
            //customer.Address = address;

            // el cliente está habilitado por defecto
            customer.Enable();



            //set default picture
            var picture = new Picture();
            picture.ChangeCurrentIdentity(customer.Id);

            customer.ChangePicture(picture);

            //set the country for this customer
            customer.SetTheCountryForThisCustomer(country);

            return customer;
        }
    }
}
