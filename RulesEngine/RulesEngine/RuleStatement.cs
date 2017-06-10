using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RulesEngine
{
    public class RuleStatement<T> : IRuleStatement<T>
    {
        private readonly IRuleStatement<T> whenConditionTrue;
        private readonly IRuleStatement<T> next;
        private readonly Func<bool> condition;
        private readonly IDictionary<bool, IRuleStatement<T>> dict = new Dictionary<bool, IRuleStatement<T>>();

        public RuleStatement(Func<bool> condition, IRuleStatement<T> whenConditionTrue, IRuleStatement<T> next)
        {
            this.condition = condition;
            this.next = next;
            this.whenConditionTrue = whenConditionTrue;
            dict.Add(true, whenConditionTrue);
            dict.Add(false, next);
        }

        public bool IsValid => condition();

        public T Process() => dict[IsValid].Process();

    }
}

