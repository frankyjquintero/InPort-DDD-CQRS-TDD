using InPort.Domain.AggregatesModel.CustomerAgg;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    /// <summary>
    /// Esta es la fábrica para la creación de ordenes de ingreso, lo que significa que el propósito principal
    /// es encapsular el conocimiento de la creación.
    /// Lo que se crea es una instancia de entidad transitoria, aún no se ha dicho nada sobre la persistencia
    /// </summary>
    public static class OrderFactory
    {

        public static OrderIncome CreateOrder(Customer customer, string mainSupportDocument, string secondarySupportDocument, string observation)
        {

            var order = new OrderIncome(mainSupportDocument, secondarySupportDocument,  observation);

            order.SetTheCustomerForThisOrder(customer);

            order.GenerateNewIdentity();

            return order;
        }
    }
}
