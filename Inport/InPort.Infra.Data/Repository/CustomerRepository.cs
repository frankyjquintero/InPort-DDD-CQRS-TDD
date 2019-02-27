using System.Collections.Generic;
using System.Linq;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace InPort.Infra.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(InPortDbContext context)
            : base(context)
        {

        }

        public Customer GetByEmail(string email)
        {
            return DbSet.AsNoTracking().FirstOrDefault(c => c.Email == email);
        }

      }
}
