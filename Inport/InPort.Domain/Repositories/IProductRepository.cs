using InPort.Domain.AggregatesModel.ProductAgg;
using InPort.Domain.Core.IRepository;

namespace InPort.Domain.Repositories
{
    public interface IProductRepository
         : IReadRepository<Product>, ICreateRepository<Product>, IRemoveRepository<Product>, IUpdateRepository<Product>
    {
    }
}
