﻿using Autofac.Core;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
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
            var dataAccess = typeof(RepositoryModule).GetTypeInfo().Assembly;

            builder.RegisterAssemblyTypes(dataAccess)
                   .Where(t => t.Name.EndsWith("Repository"))
                   .AsImplementedInterfaces()
                   .EnableInterfaceInterceptors()
                   .InstancePerLifetimeScope();

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
        }
    }
}