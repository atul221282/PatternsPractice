using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RulesEngine
{
    public class RulesWithSubCondition<T> : IRule<T>
    {
        private readonly IRule<T>[] preConidtion;
        private readonly Func<bool> condition;
        private readonly Func<T> func;
        private readonly IRule<T> next;

        public RulesWithSubCondition(IRule<T>[] preConidtion,
            Func<bool> condition, Func<T> func, IRule<T> next)
        {
            this.preConidtion = preConidtion;
            this.condition = condition;
            this.func = func;
            this.next = next;
        }

        public bool IsValid()
        {
            return condition();
        }

        public T Process()
        {
            var prevValid = preConidtion.FirstOrDefault(x => x.IsValid());

            if (prevValid != null)
                return prevValid.Process();

            if (IsValid())
                return func();

            return next.Process();
        }
    }
}
