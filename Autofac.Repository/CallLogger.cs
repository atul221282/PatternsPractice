using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Reflection;

namespace Autofac.Repository
{
    public class CallLogger : ICallLogger, IInterceptor
    {
        private readonly ITestRepository repo;
        private readonly IMemoryCache memoryCache;

        public CallLogger(ITestRepository repo, IMemoryCache memoryCache)
        //public CallLogger()
        {
            this.repo = repo;
            this.memoryCache = memoryCache;
        }

        public void Intercept(IInvocation invocation)
        {
            var key = $"{invocation.InvocationTarget.GetType().Name}={invocation.Method.Name}";

            var cacheValue = memoryCache.Get(key);

            Test(invocation);

            if (cacheValue != null)
            {
                invocation.ReturnValue = cacheValue;
            }
            else
            {
                invocation.Proceed();
                memoryCache.Set(key, invocation.ReturnValue);
            }
        }

        private static void Test(IInvocation invocation)
        {
            foreach (var arg in invocation.Arguments)
            {
                if (arg.GetType().Name == "UserModel")
                {
                    var gg = JsonConvert.SerializeObject(arg);
                }
            }
        }
    }

    public interface ICallLogger
    {
    }
}
