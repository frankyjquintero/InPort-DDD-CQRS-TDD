using System;
using System.Collections.Generic;
using System.Text;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.UnitOfWork;
using Xunit;

namespace InPort.Infra.Data.Test.Base
{
    public class QueryTestFixture : IDisposable
    {
        public InPortDbContext Context { get; private set; }
        public UnitOfWorkContainer UnitOfWork { get; private set; }

        public QueryTestFixture()
        {
            Context = InPortContextFactory.Create();
            UnitOfWork = new UnitOfWorkContainer(Context);
        }

        public void Dispose()
        {
            InPortContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
