using PiArt.Domain.Entities;
using PiArt.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PiArt.Controllers
{
    public class DealController : ApiController
    {
        DealService SD = new DealService();
        // GET: api/Deal
        public IEnumerable<Deal> Get()
        {
            return SD.GetAll();
        }

        // GET: api/Deal/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Deal
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Deal/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Deal/5
        public void Delete(int id)
        {
        }
    }
}
