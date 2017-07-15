using Autofac.Repository.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository.Valiadtor
{
    public class UserModelValidator : AbstractValidator<UserModel>
    {
        public UserModelValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
        }
    }
}
