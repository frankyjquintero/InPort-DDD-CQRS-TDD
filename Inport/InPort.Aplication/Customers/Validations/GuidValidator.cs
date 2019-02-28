using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Aplication.Customers.Validations
{
    public class GuidValidator : AbstractValidator<Guid>
    {
        public GuidValidator()
        {
            RuleFor(x => x).NotEmpty();
        }
    }
}
// https://stackoverflow.com/questions/50042201/how-to-validate-a-list-of-guid-using-fluentvalidation
//////public class DataValidator : AbstractValidator<Data>
//////{
//////    public DataValidator()
//////    {
//////        RuleFor(d => d.Ids)
//////            .NotNull() //validates whether Ids collection is null
//////            .NotEmpty() //validates whether Ids collection is empty
//////            .SetCollectionValidator(new GuidValidator()); //validates each element inside Ids collection using GuidValidator
//////    }
//////}
