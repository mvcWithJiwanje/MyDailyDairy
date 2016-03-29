using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyDailyDairy.UI.Controllers
{
    public class ValueModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class ValuesController : ApiController
    {
        // GET api/<controller>
        public object Get()
        {
            List<ValueModel> lst = new List<ValueModel>();
            lst.Add(new ValueModel{ID=1,Name="Name-01"});
            lst.Add(new ValueModel { ID = 2, Name = "Name-02" });
            return lst;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}