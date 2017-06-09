using System;
using System.Collections.Generic;
using System.Text;

namespace NullAndObjectPattern
{
    public class Users : IUsers
    {
        public Users(string name)
        {
            UserName = name;
        }
        public string UserName { get; private set; }
    }

    public class NullUsers : IUsers
    {
        public string UserName => "NullUser";
    }

    public interface IUsers
    {
        string UserName { get; }
    }
}
