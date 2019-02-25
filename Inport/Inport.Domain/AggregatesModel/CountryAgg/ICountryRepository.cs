using InPort.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.CountryAgg
{
    public interface ICountryRepository
        : IRepository<Country>
    {
    }
}
