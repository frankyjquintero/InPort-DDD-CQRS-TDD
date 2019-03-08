using System.Collections.Generic;

namespace InPort.Domain.Core.IRepository
{
    public interface IRemoveRepository<in T> where T : class
    {
        /// <summary>
        /// Remove as logic level
        /// </summary>
        /// <param name="t"></param>
        void Remove(T t);

        /// Remove collection as logic level
        void Remove(IEnumerable<T> t);
    }
}
