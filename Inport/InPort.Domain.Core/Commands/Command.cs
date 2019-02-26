using System;
using FluentValidation.Results;
using InPort.Domain.Core.Events;
using InPort.Domain.Core.Commands;

namespace InPort.Domain.Core.Commands
{
    public abstract class Command : Message, ICommand
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        public abstract bool IsValid();

    }
}