using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.Core.IRepository;

namespace InPort.Domain.Repositories
{
    public interface IMeasurentUnitRepository
        : IReadRepository<MeasurentUnit>, ICreateRepository<MeasurentUnit>, IRemoveRepository<MeasurentUnit>, IUpdateRepository<MeasurentUnit>
    {

    }
}
