using InPort.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.ProductAgg
{
    public interface IProductRepository
         : IRepository<Product>
    {
    }
}
