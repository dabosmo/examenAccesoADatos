using PlaceMyBet_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_backend.Controllers
{
    public class EventoController : ApiController
    {
        // GET: api/Evento
        public IEnumerable<EventoDTO> Get()
        {
            var repo = new EventoRepository();
            List<EventoDTO> todos = repo.RetrieveDTO();
            return todos;
        }

        // GET: api/Evento/5
        public List<EventoFor> Get(int id)
        {
            var repo = new EventoRepository();
            List<EventoFor> eventos = repo.RetrieveById(id);
            return eventos;
        }

        // POST: api/Evento
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Evento/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Evento/5
        public void Delete(int id)
        {
        }
    }
}
