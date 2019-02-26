using FluentValidation;
using InPort.Aplication.Customers.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Aplication.Customers.Validations
{
    public abstract class CustomerValidation<T> : AbstractValidator<T> where T : CustomerCommand
    {
        protected void ValidateFirstName()
        {
            RuleFor(c => c.FirstName)
                .NotEmpty().WithMessage("Por favor, asegúrese de haber ingresado el nombre")
                .Length(2, 150).WithMessage("El nombre debe tener entre 2 y 150 caracteres.");
        }
        protected void ValidateLastName()
        {
            RuleFor(c => c.LastName)
                .NotEmpty().WithMessage("Por favor, asegúrese de haber ingresado el apellido")
                .Length(2, 150).WithMessage("El apellido debe tener entre 2 y 150 caracteres.");
        }

        protected void ValidateEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }

        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }
        protected void ValidateCountryId()
        {
            RuleFor(c => c.CountryId)
                .NotEqual(Guid.Empty);
        }


    }
}
