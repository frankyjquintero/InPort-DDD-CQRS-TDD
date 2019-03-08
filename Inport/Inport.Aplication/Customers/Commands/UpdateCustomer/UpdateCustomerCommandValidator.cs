using System;
using FluentValidation;

namespace InPort.Aplication.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.Id)
               .NotEqual(Guid.Empty).WithMessage("Por favor, asegúrese de haber ingresado el Id valido");
            RuleFor(c => c.FirstName)
                     .NotEmpty().WithMessage("Por favor, asegúrese de haber ingresado el nombre")
                     .Length(2, 150).WithMessage("El nombre debe tener entre 2 y 150 caracteres.");

            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Por favor, asegúrese de haber ingresado el apellido")
                .Length(2, 150).WithMessage("El apellido debe tener entre 2 y 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();




            RuleFor(c => c.CountryId)
                .NotEqual(Guid.Empty).WithMessage("Por favor, asegúrese de haber ingresado el pais valido");
        }

    }
}
