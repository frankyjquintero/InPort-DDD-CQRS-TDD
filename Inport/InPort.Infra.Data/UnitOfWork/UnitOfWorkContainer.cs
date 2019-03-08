using System.Threading.Tasks;
using InPort.Domain;
using InPort.Infra.Data.Context;

namespace InPort.Infra.Data.UnitOfWork
{
    public class UnitOfWorkContainer : IUnitOfWork
    {
        private readonly InPortDbContext _context;
        public IUnitOfWorkRepository Repository { get; }

        public UnitOfWorkContainer(
            InPortDbContext context
        )
        {
            _context = context;
            Repository = new UnitOfWorkRepository(_context);
        }

        #region Detect Changes
        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }
        #endregion

        #region Save Changes
        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveChangesAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
        #endregion

    }
}
