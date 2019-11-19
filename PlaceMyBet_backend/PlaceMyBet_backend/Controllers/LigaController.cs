using PlaceMyBet_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_backend.Controllers
{
    public class LigaController : ApiController
    {
        // GET: api/Liga
        public IEnumerable<LigaDTO> Get()
        {
            var repo = new LigaRepository();
            List<LigaDTO> todos = repo.RetrieveDTO();
            return todos;
        }

        // GET: api/Liga/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Liga
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Liga/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Liga/5
        public void Delete(int id)
        {
        }
    }
}
