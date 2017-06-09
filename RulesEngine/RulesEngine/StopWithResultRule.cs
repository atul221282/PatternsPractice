using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RulesEngine
{
    public class StopWithResultRule<T>:IRuleStatement<T>
    {
        private readonly T Value;

        public StopWithResultRule(T Value)
        {
            this.Value = Value;
        }

        public bool IsValid()
        {
            return true;
        }

        public T Process()
        {
            return Value;
        }
    }
}
