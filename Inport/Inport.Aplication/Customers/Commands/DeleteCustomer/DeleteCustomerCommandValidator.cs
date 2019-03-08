using System;
using FluentValidation;

namespace InPort.Aplication.Customers.Commands.DeleteCustomer
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
