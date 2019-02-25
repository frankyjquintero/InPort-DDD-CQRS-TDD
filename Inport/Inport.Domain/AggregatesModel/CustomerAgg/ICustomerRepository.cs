using InPort.Domain.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CustomerAgg
{
    public interface ICustomerRepository
        : IRepository<Customer>
    {
        IEnumerable<Customer> GetEnabled(int pageIndex, int pageCount);
    }
}
