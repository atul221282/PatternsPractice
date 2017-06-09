using Autofac.Repository;
using System;

namespace Autofac.Service
{
    public class ValueService : IValueService
    {
        private readonly Lazy<IRepository> repoLazy;
        public int counter;
        public ValueService(Lazy<IRepository> repoLazy)
        {
            this.repoLazy = repoLazy;
            counter++;
        }
        public string Get()
        {
            return $"Testing Autofac {repoLazy.Value.GetRepoValue()} {counter}";
        }
    }
    public interface IValueService
    {
        string Get();
    }
}
