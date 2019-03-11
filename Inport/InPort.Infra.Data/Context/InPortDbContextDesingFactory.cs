using InPort.Infra.Data.DesingTime;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
