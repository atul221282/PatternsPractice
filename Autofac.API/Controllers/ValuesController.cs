using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Autofac.Service;
using System;
using System.Linq;

namespace Autofac.API.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly Func<IValueService> serviceFunc;
        private readonly Func<IEnumerable<ISomeService>> someServices;

        public ValuesController(Func<IValueService> serviceFunc, Func<IEnumerable<ISomeService>> someServices)
        {
            this.serviceFunc = serviceFunc;
            this.someServices = someServices;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { serviceFunc().Get(), "value2" }.Concat(this.someServices().Select(x => x.GetSome()));
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
