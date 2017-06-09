using Autofac.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Autofac.Service.Infrastructure
{
    public static class ServiceModule
    {
        public static void Register(ContainerBuilder builder)
        {
            RepositoryModule.Register(builder);

            var dataAccess = typeof(ValueService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
