using System;
using System.Linq;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            var counter = 0;
            //counter = NumberRule(counter);
            StringRule();
        }

        private static void StringRule()
        {
            for (var i = 0; i < 4; i++)
            {
                var param = Console.ReadLine();
                var result = StringRuleFactory.CreateRules(param);
                Console.WriteLine(result.Process());
                param = Console.ReadLine();
            }
        }

        private static int NumberRule(int counter)
        {
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

            return counter;
        }
    }
}