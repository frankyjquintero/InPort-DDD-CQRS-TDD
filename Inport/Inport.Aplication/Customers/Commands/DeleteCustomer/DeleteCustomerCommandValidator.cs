using FluentValidation;
using InPort.Aplication.Customers.Validations;

namespace InPort.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : CustomerValidation<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            ValidateId();
        }
    }
}
