using InPort.Aplication.Core.Commands;
using InPort.Aplication.Customers.Commands;
using MediatR;
using System;

namespace InPort.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : CustomerCommand
    {
        public DeleteCustomerCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new DeleteCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
