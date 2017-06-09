using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public class ResolveAndRunNextRule<T> : IRule<T>
    {
        private readonly Func<bool> condition;
        private readonly Func<T> func;
        private readonly IRule<T> next;

        public ResolveAndRunNextRule(Func<bool> condition, Func<T> func, IRule<T> next)
        {
            this.condition = condition;
            this.func = func;
            this.next = next;
        }

        public bool IsValid() => condition();

        public T Process() => IsValid() ? func() : next.Process();
    }
}

