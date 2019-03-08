using MediatR;

namespace InPort.Aplication.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQuery : IRequest<CustomersListViewModel>
    {
    }
}
