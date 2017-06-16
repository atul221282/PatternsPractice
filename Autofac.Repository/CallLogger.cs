using Castle.DynamicProxy;
using Microsoft.Extensions.Caching.Memory;

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
            var key = $"{invocation.MethodInvocationTarget.Name}={invocation.Method.Name}";

            var cacheValue = memoryCache.Get(key);

            if (cacheValue != null)
                invocation.ReturnValue = cacheValue;
            else
            {
                invocation.Proceed();
                memoryCache.Set(key, invocation.ReturnValue);
            }
        }
    }

    public interface ICallLogger
    {
    }
}
