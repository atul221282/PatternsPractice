using System;
using System.Linq;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;

            while (true)
            {
                var rule = RulesFactory.CreateRules(counter);

                Console.WriteLine($"{rule.Process()} === {counter}");

                if (counter > 250)
                {
                    Console.ReadLine();
                    break;
                }
                counter = counter + 10;
            }
        }
    }
}