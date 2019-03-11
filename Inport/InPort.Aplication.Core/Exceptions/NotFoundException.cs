using System;

namespace InPort.Aplication.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string name, object key)
            : base($"Entidad \"{name}\" ({key}) no fue encontrada.")
        {
        }
    }
}
