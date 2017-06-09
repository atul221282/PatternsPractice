using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using System;
using System.Reflection;

namespace Autofac.Repository.Infrastructure
{
    public static class RepositoryModule
    {
        public static void Register(ContainerBuilder builder)
        {
            var dataAccess = typeof(Repository).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .EnableClassInterceptors()
                   .InstancePerLifetimeScope();


            builder.RegisterType<CallLogger>().As<ICallLogger>()
                .Named<IInterceptor>(nameof(CallLogger));
        }
    }
}
