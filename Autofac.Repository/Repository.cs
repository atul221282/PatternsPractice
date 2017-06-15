using Autofac.Extras.DynamicProxy;
using System;

namespace Autofac.Repository
{
    [Intercept(nameof(ICallLogger))]
    public class Repository : IRepository
    {
        public virtual string GetRepoValue()
        {
            return $"TEST REPO";
        }

        public string GetById()
        {
            return $"TEST REPO BY ID";
        }
    }

    //[Intercept(nameof(ICallLogger))]
    public interface IRepository
    {
        string GetRepoValue();

        string GetById();
    }


}
