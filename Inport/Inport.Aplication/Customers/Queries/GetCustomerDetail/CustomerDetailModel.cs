using InPort.Domain.AggregatesModel.CustomerAgg;
using System;
using System.Linq.Expressions;

namespace InPort.Application.Customers.Queries.GetCustomerDetail
{
    public class CustomerDetailModel
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Country { get; set; }
        public string Fax { get; set; }
        public string Phone { get; set; }
        public string PostalCode { get; set; }
        public string Region { get; set; }

        public static Expression<Func<Customer, CustomerDetailModel>> Projection
        {
            get
            {
                return customer => new CustomerDetailModel
                {
                    Id = customer.Id.ToString(),
                    //Address = customer.Address.AddressLine1,
                    //City = customer.Address.City,
                    Country = customer.CountryId.ToString()
                };
            }
        }

        public static CustomerDetailModel Create(Customer customer)
        {
            return Projection.Compile().Invoke(customer);
        }
    }
}
