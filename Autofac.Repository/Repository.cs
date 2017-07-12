using Autofac.Extras.DynamicProxy;
using Autofac.Repository.Model;
using System;
using System.Reflection;

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

        public UserModel Save(UserModel Value, string name)
        {
            Value.GetType().GetProperty("Name").SetValue(Value, "2");

            Value.Name = $"{Value.Name} {name}";

            return Value;
        }
    }

    [Intercept(nameof(ICacheInterceptor))]
    [Intercept(nameof(ICallLogger))]
    public interface IRepository
    {
        string GetRepoValue();

        string GetById();

        UserModel Save(UserModel Value, string name);
    }
}
