using InPort.Aplication.Core.Commands;
using MediatR;
using System;

namespace InPort.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
