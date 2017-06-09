using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RulesEngine
{
    public class StopWithActionRule<T> : IRuleStatement<T>
    {
        private readonly Func<T> func;

        public StopWithActionRule(Func<T> func)
        {
            this.func = func;
        }

        public bool IsValid()
        {
            return true;
        }

        public T Process()
        {
            return func();
        }
    }
}
