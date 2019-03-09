using InPort.Domain.AggregatesModel.ProductAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(InPortDbContext context)
            : base(context)
        {
        }
    }
}