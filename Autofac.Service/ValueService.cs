using Autofac.Repository;
using Autofac.Repository.Model;
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

        public object Save()
        {
            var pp = repoLazy.Value.Save(new UserModel { Email = "Atul@Atul.com", Name = "atul" }, "Chaudhary");

            return pp;
        }
    }
    public interface IValueService
    {
        string Get();
        object Save();
    }
}
