using Autofac.Repository.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository.Valiadtor
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
