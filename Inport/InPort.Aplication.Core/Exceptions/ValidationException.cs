using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InPort.Aplication.Core.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("Se han producido uno o más errores de validación.")
        {
            Failures = new Dictionary<string, string[]>();
        }

        public ValidationException(List<ValidationFailure> failures)
            : this()
        {
            var propertyNames = failures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = failures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                Failures.Add(propertyName, propertyFailures);
            }
        }

        public IDictionary<string, string[]> Failures { get; }
    }
}
