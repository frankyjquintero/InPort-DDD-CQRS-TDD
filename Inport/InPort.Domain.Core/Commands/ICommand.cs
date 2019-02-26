using System;
using FluentValidation.Results;

namespace InPort.Domain.Core.Commands
{
    public interface ICommand
    {
        DateTime Timestamp { get; }
        ValidationResult ValidationResult { get; set; }

        bool IsValid();
    }
}