using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Core.IRepository;

namespace InPort.Domain.Repositories
{
    public interface ICountryRepository
        : IReadRepository<Country>,
            ICreateRepository<Country>,
            IRemoveRepository<Country>,
            IUpdateRepository<Country>
    {
    }
}
