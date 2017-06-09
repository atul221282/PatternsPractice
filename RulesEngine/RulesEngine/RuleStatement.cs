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

        public RuleStatement(Func<bool> condition, IRuleStatement<T> whenConditionTrue, IRuleStatement<T> next)
        {
            this.condition = condition;
            this.next = next;
            this.whenConditionTrue = whenConditionTrue;
        }

        public bool IsValid() => condition();

        public T Process()
        {
            if (IsValid())
                return whenConditionTrue.Process();

            return next.Process();
        }
    }
}

