using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository
{
    public class CacheInterceptor : ICacheInterceptor, IInterceptor
    {
        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
        }
    }

    public interface ICacheInterceptor
    {
    }
}
