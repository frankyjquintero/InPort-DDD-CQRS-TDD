using InPort.Domain.Core.Querys;
using MediatR;

namespace InPort.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {
    }
}
