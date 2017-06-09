using Autofac.Extras.DynamicProxy;
using System;

namespace Autofac.Repository
{
    [Intercept(nameof(CallLogger))]
    public class Repository : IRepository
    {
        public virtual string GetRepoValue()
        {
            return $"TEST REPO";
        }
    }


    public interface IRepository
    {
        string GetRepoValue();
    }
}
