using InPort.Domain.Repositories;

namespace InPort.Domain
{
    public interface IUnitOfWorkRepository
    {
        ICustomerRepository CustomerRepository { get; }
        ICountryRepository CountryRepository { get; }
        IMeasurentUnitRepository MeasurentUnitRepository { get; }
        IOrderIncomeRepository OrderIncomeRepository { get; }
        IProductRepository ProductRepository { get; }
    }
}