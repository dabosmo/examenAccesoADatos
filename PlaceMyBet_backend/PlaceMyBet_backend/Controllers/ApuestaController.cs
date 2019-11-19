﻿using PlaceMyBet_backend.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PlaceMyBet_backend.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/Apuesta
        public IEnumerable<ApuestaDTO> Get()
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> todos = repo.RetrieveDTO();
            return todos;
        }

        // GET: api/Apuesta?email=emailvalido(p.ej daniel@gmail.com)
        public IEnumerable<ApuestaDTO> Get(string email)
        {
            var repo = new ApuestaRepository();
            List<ApuestaDTO> apuestas = repo.RetrieveByEmail(email);
            return apuestas;
        }

        // POST: api/Apuesta
        //[Authorize(Roles = "Admin")]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo = new ApuestaRepository();
            repo.Save(apuesta);
            Debug.WriteLine(apuesta.Id);
            repo.Update(apuesta.MercadoId);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
