using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core.IRepository;

namespace InPort.Domain.Repositories
{
    public interface ICustomerRepository : IReadRepository<Customer>,
        ICreateRepository<Customer>,
        IRemoveRepository<Customer>,
        IUpdateRepository<Customer>
        
    {
        Customer GetByEmail(string email);
    }
}
