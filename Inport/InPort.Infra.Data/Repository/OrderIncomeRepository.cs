using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.Repository
{
    public class OrderIncomeRepository : GenericRepository<OrderIncome>, IOrderIncomeRepository
    {
        public OrderIncomeRepository(InPortDbContext context)
            : base(context)
        {
        }
    }
}