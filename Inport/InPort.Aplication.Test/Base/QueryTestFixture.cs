using System;
using System.Collections;
using System.Linq;
using InPort.Domain.Core.Notifications;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.UnitOfWork;
using MediatR;
using Xunit;

namespace InPort.Aplication.Test.Base
{
    public class QueryTestFixture : IDisposable
    {
        public InPortDbContext Context { get; private set; }
        public UnitOfWorkContainer UnitOfWork { get; private set; }
        public Mediator Bus { get; private set; }
        public DomainNotificationHandler Notifications { get; private set; }

        public QueryTestFixture()
        {
            Context = InPortContextFactory.Create();
            UnitOfWork = new UnitOfWorkContainer(Context);
            var serviceFactory = new ServiceFactory(type =>
                typeof(IEnumerable).IsAssignableFrom(type)
                    ? Array.CreateInstance(type.GetGenericArguments().First(), 0)
                    : null);
            Bus = new Mediator(serviceFactory);
            Notifications = new DomainNotificationHandler();

        }

        public void Dispose()
        {
            InPortContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
