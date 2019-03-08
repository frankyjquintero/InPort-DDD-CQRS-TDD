using System;
using System.Collections.Generic;
using System.Text;
using InPort.Domain.AggregatesModel.CountryAgg;
using InPort.Domain.Repositories;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.Repository
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
        public CountryRepository(
            InPortDbContext context
        ) : base(context)
        {
        }

    }
}
