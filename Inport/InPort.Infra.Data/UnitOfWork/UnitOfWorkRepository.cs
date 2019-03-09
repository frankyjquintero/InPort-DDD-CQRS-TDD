using InPort.Domain;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.Repository;

namespace InPort.Infra.Data.UnitOfWork
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        public ICustomerRepository CustomerRepository { get; }
        public ICountryRepository CountryRepository { get; }
        public IMeasurentUnitRepository MeasurentUnitRepository { get; }
        public IOrderIncomeRepository OrderIncomeRepository { get; }
        public IProductRepository ProductRepository { get; }

        public UnitOfWorkRepository(InPortDbContext context)
        {
            CustomerRepository = new CustomerRepository(context);
            CountryRepository = new CountryRepository(context);
            MeasurentUnitRepository = new MeasurentUnitRepository(context);
            OrderIncomeRepository = new OrderIncomeRepository(context);
            ProductRepository = new ProductRepository(context);
        }

       
    }
}
