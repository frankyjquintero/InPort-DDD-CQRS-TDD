using System;
using System.Collections.Generic;
using System.Text;

namespace InPort.Aplication.Core.Exceptions
{
    public class DeleteFailureException : Exception
    {
        public DeleteFailureException(string name, object key, string message)
            : base($"Eliminacion de entidad \"{name}\" ({key}) fallo. {message}")
        {
        }
    }
}
