using System;
using MediatR;

namespace InPort.Aplication.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
