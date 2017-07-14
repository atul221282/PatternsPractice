using System;
using System.Collections.Concurrent;

namespace ConcurrentDictonaryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var mc = new MyCache();

            Console.WriteLine(mc.GetOrAdd(1));

            Console.WriteLine(mc.GetOrAdd(2));

            Console.ReadKey();
        }
    }

    public class MyCache
    {
        private readonly ConcurrentDictionary<int, string> cache;

        public MyCache()
        {
            this.cache = new ConcurrentDictionary<int, string>();
            this.cache.TryAdd(2, "Kapil");
        }

        public string GetOrAdd(int id)
        {
            return this.cache.GetOrAdd(id, "Atul");
        }
    }
}