using PlaceMyBet_backend.Models;
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
            Debug.WriteLine("ENTRO EN EL OTRO");
            var repo = new ApuestaRepository();
            List<ApuestaDTO> todos = repo.RetrieveDTO();
            return todos;
        }
        /*** Ejercicio 2 ***/
        // GET: api/Apuesta?idMercado=16 el entero es la id del mercado
        public IEnumerable<ApuestaExamen> Get(int idMercado)
        {
            Debug.WriteLine("ENTRO EN APUESTADS REPOSITORY");
            var repository = new ApuestaRepository();
            List<ApuestaExamen> apuestas = repository.RetrieveByIdMercado(idMercado);
            return apuestas;
        }
        /*** Fin ejercicio 2 ***/

        // GET: api/Apuesta?email=emailvalido(p.ej daniel@gmail.com)
        public IEnumerable<ApuestaDTO> Get(string email)
        {
            Debug.WriteLine("ENTRO EN EL OTRO");
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
