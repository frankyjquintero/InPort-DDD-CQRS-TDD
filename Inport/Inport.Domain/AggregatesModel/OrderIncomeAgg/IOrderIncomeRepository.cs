using InPort.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Domain.AggregatesModel.OrderIncomeAgg
{
    /// <summary>
    /// El contrato para el repositorio de ordenes de Ingreso
    /// </summary>
    public interface IOrderIncomeRepository
    : IRepository<OrderIncome>
    {
    }
}
