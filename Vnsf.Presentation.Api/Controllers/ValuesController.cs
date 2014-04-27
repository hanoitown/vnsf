using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Vnsf.Presentation.Api.Controllers
{
    public class ValuesController : ApiController
    {
        private ICalculator calculator;

        public ValuesController(ICalculator calculator)
        {
            this.calculator = calculator;
        }
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new List<string> { calculator.increase(2) };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}