using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public class RulesFactory
    {
        public static IRule<int> CreateRules(int number)
        {
            //when less than 100 but greater then 10
            var between11And100 = Between11And100(number, Between101And200(number));
            //when less than equal to 10 but greater then 1
            var between1And10 = Between1And10(number, between11And100);

            var valueZeroRule = new ResolveAndRunNextRule<int>(() => number == 0, () => -1, between1And10);
            //return rule
            return valueZeroRule;
        }

        private static IRule<int> Between101And200(int number)
        {
            var whenLessThan200 = new ResolveAndRunNextRule<int>(() => number > 150 && number <= 200, () => 199, new StopRule<int>(200));
            var whenLessThan150 = new ResolveAndRunNextRule<int>(() => number <= 150, () => 149, new StopRule<int>(200));

            var whenGreaterThan100LessThan200 = new RulesWithSubCondition<int>(new IRule<int>[] { whenLessThan150, whenLessThan200 },
                () => number >= 100, () => 200, new StopRule<int>(200));

            return whenGreaterThan100LessThan200;
        }

        /// <summary>
        /// >10 && <=100
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static RulesWithSubCondition<int> Between11And100(int number, IRule<int> Between101And200)
        {
            var stopAt100 = new StopRule<int>(100);
            var whenEqualTo60 = new ResolveAndRunNextRule<int>(() => number == 60, () => 60, stopAt100);
            var whenEqualTo50 = new ResolveAndRunNextRule<int>(() => number == 50, () => 50, stopAt100);
            var greaterThan10LessThan100 = new RulesWithSubCondition<int>(new IRule<int>[] { whenEqualTo50, whenEqualTo60, stopAt100 },
                () => number <= 100, () => 100, Between101And200);

            return greaterThan10LessThan100;
        }

        /// <summary>
        /// >=1 && <=10
        /// </summary>
        /// <param name="number"></param>
        /// <param name="greaterThan10LessThan100"></param>
        /// <returns></returns>
        private static RulesWithSubCondition<int> Between1And10(int number, RulesWithSubCondition<int> greaterThan10LessThan100)
        {
            var stopAt10 = new StopRule<int>(10);
            var between1And5 = new ResolveAndRunNextRule<int>(() => number >= 1 && number < 5, () => 1, stopAt10);
            var between5And9 = new ResolveAndRunNextRule<int>(() => number > 4 && number <= 9, () => 9, stopAt10);
            var return0WhenLessThan10 = new ResolveAndRunNextRule<int>(() => number <= 10, () => 10, greaterThan10LessThan100);
            var valueLessThan10Rule = new RulesWithSubCondition<int>(new IRule<int>[] { between1And5, between5And9 }, () => number == 10, () => 10,
                return0WhenLessThan10);
            return valueLessThan10Rule;
        }

    }
}
