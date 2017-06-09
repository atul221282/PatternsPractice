using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Service
{
    public class SomeService : ISomeService
    {
        public int Counter { get; private set; }
        public SomeService()
        {
            Counter++;
        }
        public string GetSome()
        {
            return $"Some service {Counter}";
        }
    }


    public class AwesomeSomeService : ISomeService
    {
        public int Counter { get; private set; }
        public AwesomeSomeService()
        {
            Counter++;
        }
        public string GetSome()
        {
            return $"Awesome service {Counter}";
        }
    }

    public class MyAwesomeSomeService : ISomeService
    {
        public int Counter { get; private set; }
        public MyAwesomeSomeService()
        {
            Counter++;
        }
        public string GetSome()
        {
            return $"My Awesome service {Counter}";
        }
    }

    public interface ISomeService
    {
        int Counter { get; }
        string GetSome();
    }
}
