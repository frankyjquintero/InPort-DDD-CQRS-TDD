using AutoMapper;
using AutoMapper.QueryableExtensions;
using InPort.Infra.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InPort.Application.Customers.Queries.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListViewModel>
    {
        private readonly InPortContext _context;
        private readonly IMapper _mapper;

        public GetCustomersListQueryHandler(InPortContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomersListViewModel> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            return new CustomersListViewModel
            {
                Customers = await _context.Customers.ProjectTo<CustomerLookupModel>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken)
            };
        }
    }
}
