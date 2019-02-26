using FluentValidation;
using InPort.Aplication.Customers.Validations;

namespace InPort.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator : CustomerValidation<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }
    }
}
