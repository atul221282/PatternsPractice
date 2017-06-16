using Autofac.Extras.DynamicProxy;
using System;

namespace Autofac.Repository
{
    public class Repository : IRepository
    {
        public string GetRepoValue()
        {
            return $"TEST REPO";
        }

        public string GetById()
        {
            return $"TEST REPO BY ID";
        }
    }

    [Intercept(nameof(ICacheInterceptor))]
    [Intercept(nameof(ICallLogger))]
    public interface IRepository
    {
        string GetRepoValue();

        string GetById();
    }
}
