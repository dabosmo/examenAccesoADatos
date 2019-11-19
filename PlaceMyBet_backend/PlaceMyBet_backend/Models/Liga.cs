using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class Liga
    {
        private string _abreviatura;
        private string _nombre;

        public string Abreviatura { get => _abreviatura; set => _abreviatura = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public Liga (string abreviatura, string nombre)
        {
            Nombre = nombre;
            Abreviatura = abreviatura;
        }
    }

    public class LigaDTO
    {
        private string _abreviatura;
        private string _nombre;

        public string Abreviatura { get => _abreviatura; set => _abreviatura = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }

        public LigaDTO(string abreviatura, string nombre)
        {
            Nombre = nombre;
            Abreviatura = abreviatura;
        }
    }
}