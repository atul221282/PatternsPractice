using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public class StringRuleFactory
    {
        public static IRule<string> CreateRules(string value)
        {
            var ihaName = new ResolveAndRunNextRule<string>(() => value.StartsWith("i"), () => "Ishana Chaudhary", new StopRule<string>("Bani"));
            return new ResolveAndRunNextRule<string>(() => value.StartsWith("a"), () => "atul chaudhary", ihaName);
        }
    }
}
