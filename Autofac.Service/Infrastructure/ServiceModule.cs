using Autofac.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Autofac.Service.Infrastructure
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<RepositoryModule>();

            var dataAccess = typeof(ValueService).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith(@"Service"))
                   .AsImplementedInterfaces()
                   .InstancePerLifetimeScope();
        }
    }
}
