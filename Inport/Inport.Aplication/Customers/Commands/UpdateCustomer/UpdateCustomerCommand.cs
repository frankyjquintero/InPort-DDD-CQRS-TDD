using InPort.Aplication.Core.Commands;
using InPort.Aplication.Customers.Commands;
using MediatR;
using System;

namespace InPort.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : CustomerCommand
    {
        public UpdateCustomerCommand(Guid id, string name, string email, DateTime birthDate)
        {
            Id = id;
            FirstName = name;
            Email = email;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
