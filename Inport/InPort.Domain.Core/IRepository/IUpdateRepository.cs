using System.Collections.Generic;

namespace InPort.Domain.Core.IRepository
{
    public interface IUpdateRepository<in T> where T : class
    {
        void Update(T t);
        void Update(IEnumerable<T> t);
    }
}
