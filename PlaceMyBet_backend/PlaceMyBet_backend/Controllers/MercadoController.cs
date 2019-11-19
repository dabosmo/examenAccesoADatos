using PlaceMyBet_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_backend.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<MercadoDTO> Get()
        {
            var repo = new MercadoRepository();
            List<MercadoDTO> mercados = repo.RetrieveDTO();
            return mercados;
        }

        // GET: api/Mercado/5
        [Authorize (Roles = "Admin")]
        public IEnumerable<MercadoFor> Get(int id)
        {
            var repo = new MercadoRepository();
            List<MercadoFor> mercados = repo.RetrieveById(id);
            return mercados;
        }

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
