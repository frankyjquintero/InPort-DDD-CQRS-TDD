using InPort.Domain.AggregatesModel.MeasurentUnitAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.Repository
{
    public class MeasurentUnitRepository : GenericRepository<MeasurentUnit>, IMeasurentUnitRepository
    {
        public MeasurentUnitRepository(InPortDbContext context)
            : base(context)
        {
        }
    }
}