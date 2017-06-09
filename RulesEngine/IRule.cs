using System;
using System.Collections.Generic;
using System.Text;

namespace RulesEngine
{
    public interface IRule<T>
    {
        bool IsValid();
        T Process();
    }
}
