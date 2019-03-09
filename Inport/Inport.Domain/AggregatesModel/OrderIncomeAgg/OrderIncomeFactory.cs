using InPort.Domain.AggregatesModel.CustomerAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    /// <summary>
    /// Esta es la fábrica para la creación de ordenes de ingreso, lo que significa que el propósito principal
    /// es encapsular el conocimiento de la creación.
    /// Lo que se crea es una instancia de entidad transitoria, aún no se ha dicho nada sobre la persistencia
    /// </summary>
    public static class OrderFactory
    {

        public static OrderIncome CreateOrder(Customer customer)
        {
            //create the order
            var order = new OrderIncome
            {


                //set default values
                //OrderDate = DateTime.UtcNow
            };


            //set customer information
            order.SetTheCustomerForThisOrder(customer);

            //set identity
            order.GenerateNewIdentity();

            return order;
        }
    }
}
