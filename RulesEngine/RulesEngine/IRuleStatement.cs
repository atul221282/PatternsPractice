using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine.RulesEngine
{
    public interface IRuleStatement<T>
    {
        bool IsValid { get; }

        T Process();
    }
}
