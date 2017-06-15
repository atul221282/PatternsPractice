using Autofac.Service;
using Autofac.Service.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Autofac.API
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            // The generic ILogger<TCategoryName> service was added to the ServiceCollection by ASP.NET Core.
            // It was then registered with Autofac using the Populate method in ConfigureServices.
            //builder.RegisterType<ValueService>().As<IValueService>()
            //    .InstancePerLifetimeScope();
            builder.RegisterModule<ServiceModule>();
        }
    }
}
