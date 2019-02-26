using System.Threading;
using System.Threading.Tasks;
using InPort.Infra.Data.Context;
using MediatR;


namespace InPort.Application.Customers.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryHandler : IRequestHandler<GetCustomerDetailQuery, CustomerDetailModel>
    {
        private readonly InPortContext _context;

        public GetCustomerDetailQueryHandler(InPortContext context)
        {
            _context = context;
        }

        public async Task<CustomerDetailModel> Handle(GetCustomerDetailQuery request, CancellationToken cancellationToken)
        {
            //var entity = await _context.Customers
            //    .FindAsync(request.Id);

            //if (entity == null)
            //{
            //    throw new NotFoundException(nameof(Customer), request.Id);
            //}

            //return CustomerDetailModel.Create(entity);
            return null;
        }
    }
}
