using InPort.Aplication.Core.Commands;
using InPort.Aplication.Customers.Commands;
using MediatR;
using System;

namespace InPort.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : CustomerCommand
    {
        public CreateCustomerCommand(string name, string email, DateTime birthDate)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateCustomerCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
