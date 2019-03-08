using System.Threading.Tasks;

namespace InPort.Domain
{
    public interface IUnitOfWork
    {
        void DetectChanges();
        bool SaveChanges();
        Task<bool> SaveChangesAsync();
        IUnitOfWorkRepository Repository { get; }
    }
}