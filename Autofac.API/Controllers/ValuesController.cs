using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Autofac.Service;
using System;
using System.Linq;
using AutoMapper;
using Autofac.Repository.Model;
using System.Reflection;
using FluentValidation;

namespace Autofac.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly Func<IValueService> serviceFunc;
        private readonly Func<IEnumerable<ISomeService>> someServices;
        private readonly Lazy<IValidator<UserModel>> validator;
        private readonly Lazy<IValidator<User>> userValidator;
        private readonly Lazy<IMapper> mapper;

        public ValuesController(Func<IValueService> serviceFunc,
            Func<IEnumerable<ISomeService>> someServices, Lazy<IMapper> mapper,
            Lazy<IValidator<UserModel>> validator, Lazy<IValidator<User>> userValidator)
        {
            this.serviceFunc = serviceFunc;
            this.someServices = someServices;
            this.mapper = mapper;
            this.validator = validator;
            this.userValidator = userValidator;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var pp = new User();

            var mapperPp = mapper.Value.Map<UserModel>(pp);

            userValidator.Value.ValidateAndThrow(pp);

            validator.Value.ValidateAndThrow(mapperPp);

            var values = serviceFunc().Get();

            var data = this.serviceFunc().Save();

            var result = new string[] { data.GetType().GetProperty("Name").GetValue(data).ToString() };

            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return $"{serviceFunc().Get()}-{id}";
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]string value)
        {
            return NoContent();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}