using FluentValidation;
using System;

namespace InPort.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
    {
        public DeleteCustomerCommandValidator()
        {
            RuleFor(c => c.Id)
               .NotEqual(Guid.Empty).WithMessage("Por favor, asegúrese de haber ingresado el Id valido"); 
        }
    }
}
