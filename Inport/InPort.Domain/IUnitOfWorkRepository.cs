using InPort.Domain.Repositories;

namespace InPort.Domain
{
    public interface IUnitOfWorkRepository
    {
        ICustomerRepository CustomerRepository { get; }
        ICountryRepository CountryRepository { get; }
    }
}