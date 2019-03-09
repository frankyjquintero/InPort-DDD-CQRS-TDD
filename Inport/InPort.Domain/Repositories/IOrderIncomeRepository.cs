using InPort.Domain.AggregatesModel.OrderIncomeAgg;
using InPort.Domain.Core.IRepository;

namespace InPort.Domain.Repositories
{
    /// <summary>
    /// El contrato para el repositorio de ordenes de Longitud
    /// </summary>
    public interface IOrderIncomeRepository
        : IReadRepository<OrderIncome>, ICreateRepository<OrderIncome>, IRemoveRepository<OrderIncome>, IUpdateRepository<OrderIncome>
    {
    }
}
