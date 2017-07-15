using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Autofac.Repository.Model;
using Autofac.Repository.Valiadtor;
using Castle.DynamicProxy;
using FluentValidation;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Autofac.Repository.Infrastructure
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var dataAccess = typeof(RepositoryModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith(@"Repository"))
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                  .Where(t => t.Name.EndsWith("Validator"))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();

            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            //builder.RegisterType<Repository>()
            //    .As<IRepository>()
            //    .InstancePerLifetimeScope()
            //      .InterceptedBy(typeof(ICallLogger))
            //    .EnableInterfaceInterceptors();

            //builder.Register(c => new CallLogger());
            //builder.Register(c => new CallLogger(c.Resolve<ITestRepository>(), c.Resolve<IMemoryCache>()));
            builder.RegisterType<CallLogger>().As<ICallLogger>().Named<IInterceptor>(nameof(ICallLogger));
            builder.RegisterType<CacheInterceptor>().As<ICacheInterceptor>().Named<IInterceptor>(nameof(ICacheInterceptor));
            //builder.RegisterType<CallLogger>().As<ICallLogger>()
            //    .UsingConstructor(typeof(ITestRepository), typeof(IMemoryCache));
            base.Load(builder);

        }
    }
}