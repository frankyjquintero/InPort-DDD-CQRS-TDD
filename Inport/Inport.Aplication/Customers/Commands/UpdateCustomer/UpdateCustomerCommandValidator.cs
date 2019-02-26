using FluentValidation;
using FluentValidation.Validators;
using InPort.Aplication.Customers.Validations;

namespace InPort.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : CustomerValidation<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            ValidateId();
            ValidateName();
            ValidateBirthDate();
            ValidateEmail();
        }

    }
}
