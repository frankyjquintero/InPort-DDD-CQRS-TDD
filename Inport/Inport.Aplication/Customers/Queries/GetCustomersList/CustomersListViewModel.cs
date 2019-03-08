using System.Collections.Generic;

namespace InPort.Aplication.Customers.Queries.GetCustomersList
{
    public class CustomersListViewModel
    {
        public IList<CustomerLookupModel> Customers { get; set; }
    }
}
