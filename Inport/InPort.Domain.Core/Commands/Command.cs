using System;
using FluentValidation.Results;
using InPort.Domain.Core.Events;
using InPort.Domain.Core.Commands;

namespace InPort.Domain.Core.Commands
{
    public abstract class Command :  ICommand
    {
 
        public virtual DateTime Timestamp { get; private set; }
        //public virtual ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }
        //public abstract bool IsValid();

    }
}