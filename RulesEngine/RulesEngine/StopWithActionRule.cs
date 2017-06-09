using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RulesEngine
{
    public class StopWithActionRule<T> : IRuleStatement<T>
    {
        private readonly Action action;
        private readonly T Value;

        public StopWithActionRule(T Value, Action action)
        {
            this.Value = Value;
            this.action = action;
        }

        public bool IsValid()
        {
            return true;
        }

        public T Process()
        {
            action();
            return Value;
        }
    }
}
