using InPort.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public interface ICustomerRepository
        : IRepository<Customer>
    {
        Customer GetByEmail(string email);
    }
}
