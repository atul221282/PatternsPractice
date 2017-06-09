using SpecialApp.Base;
using System;

namespace NullAndObjectPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i <= 2; i++)
            {
                var name = Console.ReadLine();
                Console.WriteLine(CalculateName(name));
            }
            Console.ReadLine();
        }

        public static string CalculateName(string name)
        {
            var ishanaName = new ChainRules(() => name.StartsWith("i"), () => "bani", new StopRules());
            var ihaName = new ChainRules(() => name.StartsWith("i"), () => "bani", ishanaName);
            var bName = new ChainRules(() => name == "b", () => "bani", ihaName);

            if (name == "b")
                return "bani";

            else if (name.StartsWith("i"))
            {
                if (name.StartsWith("ish"))
                    return "ISHANA";
                return "IHA";
            }
            else if (name.StartsWith("a"))
            {
                if (name.StartsWith("at"))
                    return "at";

                return "atul";
            }
            else if (name.StartsWith("s"))
            {
                if (name.StartsWith("su"))
                    return "sudarshana";

                return "sonia";
            }
            return "Hasrbans";
        }
    }

    public class ChainRules : IChainRules
    {
        private readonly IChainRules next;
        private readonly Func<string> func;
        private readonly Func<bool> onTrue;

        public ChainRules(Func<bool> onTrue, Func<string> func, IChainRules next)
        {
            this.onTrue = onTrue;
            this.func = func;
            this.next = next;
        }

        public string Process()
        {
            return onTrue().ProcessTrueOrFalse(func, () => next.Process());
        }
    }

    public class StopRules : IChainRules
    {
        public string Process()
        {
            return "Harbans";
        }
    }

    public interface IChainRules
    {
        string Process();
    }

    public static class WaiseHi
    {
        public static T ProcessTrueOrFalse<T>(this bool Value, Func<T> whenTrue, Func<T> whenFalse)
        {
            if (Value)
                return whenTrue();

            return whenFalse();
        }
    }

}