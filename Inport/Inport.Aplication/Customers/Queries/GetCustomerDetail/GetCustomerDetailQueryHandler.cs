using System.Threading;
using System.Threading.Tasks;
using MediatR;
using InPort.Application.Exceptions;
using InPort.Domain.Entities;
using InPort.Persistence;

namespace InPort.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailModel>
    {
        private readonly InPortDbContext _context;

        public GetCustomerDetailQueryHandler(InPortDbContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Customers
                .FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }

            return CustomerDetailModel.Create(entity);
        }
    }
}
