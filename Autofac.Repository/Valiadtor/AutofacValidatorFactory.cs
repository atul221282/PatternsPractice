﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Autofac.Repository.Valiadtor
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            if (_context.TryResolve(validatorType, out object instance))
            {
                var validator = instance as IValidator;
                return validator;
            }

            return null;
        }
    }
}
