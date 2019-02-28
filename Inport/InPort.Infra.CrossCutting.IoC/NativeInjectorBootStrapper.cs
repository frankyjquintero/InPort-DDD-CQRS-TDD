using AutoMapper;
using InPort.Aplication;
using InPort.Aplication.Core;
using InPort.Domain.AggregatesModel.CustomerAgg;
using InPort.Domain.Core;
using InPort.Domain.Core.Events;
using InPort.Domain.Core.Notifications;
using InPort.Infra.Core;
using InPort.Infra.CrossCutting.Bus;
using InPort.Infra.CrossCutting.Identity.Authorization;
using InPort.Infra.CrossCutting.Identity.Data;
using InPort.Infra.CrossCutting.Identity.Models;
using InPort.Infra.CrossCutting.Identity.Services;
using InPort.Infra.Data.Context;
using InPort.Infra.Data.EventSourcing;
using InPort.Infra.Data.Repository;
using InPort.Infra.Data.Repository.EventSourcing;
using InPort.Infra.Data.UoW;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace InPort.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AplicationRefAssembly).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<IDateTime, MachineDateTime>();

            // Domain - Commands
            // Domain - Events => Pipeline de MediaR
            // Add MediatR

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(AplicationRefAssembly).GetTypeInfo().Assembly);


            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<InPortDbContext>();



            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();

            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
            services.AddIdentity<ApplicationUser, IdentityRole>()
               .AddEntityFrameworkStores<ApplicationDbContext>()
               .AddDefaultTokenProviders();


            //////services
            //////    .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
            //////    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            //////    .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateCustomerCommandValidator>());
        }
    }
}
