using RulesEngine.RulesEngine;
using System;
using System.Linq;

namespace RulesEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            RuleStatement();
        }

        private static void RuleStatement()
        {
            for (var i = 0; i <= 6; i++)
            {
                var name = Console.ReadLine();

                var soRule = new RuleStatement<string>(() => name == "so",
                    new StopWithResultRule<string>("sonam"),
                    new StopWithResultRule<string>("sarah"));

                var kRule = new RuleStatement<string>(() => name == "k",
                    new StopWithResultRule<string>("kapil"),
                    new StopWithResultRule<string>("no name"));

                var prule = new RuleStatement<string>(() => name.StartsWith("p"),
                    new StopWithResultRule<string>("peter"),
                    kRule);

                var sRule = new RuleStatement<string>(() => name.StartsWith("s"), soRule, prule);


                Console.Write($"{sRule.Process()}==={name}");
                Console.WriteLine(Environment.NewLine);
                Console.ReadLine();
            }

            /*
                if name starts with s
                   if name=so
                       return sonam;
                   else
                       return sarah
                else
                    if name starts with p
                        return peter
                    else
                        if name=k
                        return kapil;
                return noname
            */
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