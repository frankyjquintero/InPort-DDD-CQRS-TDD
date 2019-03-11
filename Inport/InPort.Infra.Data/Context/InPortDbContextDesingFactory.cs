using InPort.Infra.Data.DesingTime;
using Microsoft.EntityFrameworkCore;

namespace InPort.Infra.Data.Context
{
     public class InPortDbContextDesingFactory : DesignTimeDbContextFactoryBase<InPortDbContext>
    {
        protected override InPortDbContext CreateNewInstance(DbContextOptions<InPortDbContext> options)
        {
            return new InPortDbContext(options);
        }
    }
}
