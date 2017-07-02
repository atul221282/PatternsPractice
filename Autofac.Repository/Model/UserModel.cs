using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository.Model
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public User()
        {
            this.Name = "Atul";
            this.Email = "atul221282@gmail.com";
        }
    }
}
