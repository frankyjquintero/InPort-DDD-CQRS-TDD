using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InPort.Domain.Core
{
    /// <summary>
    /// Contrato para 'Unit of Work Pattern'
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Confirma los cambios realizados en un contenedor.
        /// </summary>
        /// <returns>Número de registros confirmados.</returns>
        int Commit();

        /// <summary>
        /// Asíncronamente confirma los cambios realizados en un contenedor.
        /// </summary>
        /// <returns>Número de registros confirmados.</returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Commit all changes made in  a container.
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then 'client changes' are refreshed - Client wins
        ///</remarks>
        void CommitAndRefreshChanges();

        /// <summary>
        /// Commit all changes made in  a container. Async
        /// </summary>
        ///<remarks>
        /// If the entity have fixed properties and any optimistic concurrency problem exists,
        /// then 'client changes' are refreshed - Client wins
        ///</remarks>
        Task<int> CommitAndRefreshChangesAsync();
        /// <summary>
        /// Deshace los cambios realizados en un contenedor.
        /// </summary>
        void RollbackChanges();

        /// <summary>
        /// Reload an entity with refresh option (Note. This generates adhoc querys)
        /// </summary>
        /// <param name="entity"></param>
        void Refresh(object entity);
    }
}
