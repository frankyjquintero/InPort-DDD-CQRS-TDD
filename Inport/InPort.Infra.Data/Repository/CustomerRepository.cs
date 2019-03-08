using System.Collections.Generic;
using System.Linq;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.Repository
{
    public class CustomerRepository :  GenericRepository<Customer>, ICustomerRepository
    {

        public CustomerRepository(
            InPortDbContext context
        ): base(context)
        {
        }

        public IEnumerable<Customer> GetEnabled(int pageIndex, int pageCount)
        {
   

            return Context.Customers
                .Where(c => c.IsEnabled == true)
                .OrderBy(c => c.FullName)
                .Skip(pageIndex * pageCount)
                .Take(pageCount);
        }

        public Customer GetByEmail(string email)
        {
            throw new System.NotImplementedException();
        }
    }
}
