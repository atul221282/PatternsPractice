using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Repository.Infrastructure
{
    public class RepositoryModule : Module
    {
        const string InterceptorsPropertyName = "Autofac.Extras.DynamicProxy2.RegistrationExtensions.InterceptorsPropertyName";

        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = typeof(Repository).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .EnableClassInterceptors()
                   .InstancePerLifetimeScope();


            builder.RegisterType<CallLogger>().As<ICallLogger>()
                .InstancePerLifetimeScope()
                .Named<IInterceptor>(nameof(ICallLogger));

            //builder.RegisterType<CallLogger>().As<ICallLogger>()
            //.Named<IInterceptor>(nameof(ICallLogger))
            //.InstancePerLifetimeScope();

            //builder.RegisterType<Repository>()
            //    .As<IRepository>()
            //    .EnableClassInterceptors()
            //    .InterceptedBy(typeof(CallLogger))
            //    .InstancePerLifetimeScope();

        }
    }
}
