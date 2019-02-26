using System;

namespace InPort.Domain.Core
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
