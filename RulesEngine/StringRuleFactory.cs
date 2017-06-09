using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public class StringRuleFactory
    {
        public static IRule<string> CreateRules(string value)
        {
            var nameSam = new ResolveAndRunNextRule<string>(
                () => value.StartsWith("sa"),
                () => "Sam",
                new StopRule<string>("some with s")
            );

            var nameSumantha = new ResolveAndRunNextRule<string>(
                () => value.StartsWith("sum"),
                () => "Sumantha",
                new StopRule<string>("some with s")
            );

            var nameWithS = new RulesWithSubCondition<string>(new IRule<string>[] { nameSam, nameSumantha },
                () => value.StartsWith("s"), () => "some with s", new StopRule<string>("some with s"));

            var ihaName = new ResolveAndRunNextRule<string>(
                () => value.StartsWith("i"),
                () => "Ishana Chaudhary", nameWithS
            );

            return new ResolveAndRunNextRule<string>(
                () => value.StartsWith("a"),
                () => "atul chaudhary",
                ihaName
            );
        }
    }
}
