using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RulesEngine
{
    public class StopRule<T> : IRule<T>
    {
        private readonly T number;

        public StopRule(T number)
        {
            this.number = number;
        }

        public bool IsValid()
        {
            return false;
        }


        public T Process()
        {
            return number;
        }
    }
}
