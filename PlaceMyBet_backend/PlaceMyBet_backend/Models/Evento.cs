using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class Evento
    {
        private int _id;
        private string _equipo_local;
        private string _equipo_visitante;

        public int Id { get => _id; set => _id = value; }
        public string Equipo_local { get => _equipo_local; set => _equipo_local = value; }
        public string Equipo_visitante { get => _equipo_visitante; set => _equipo_visitante = value; }

        public Evento(int id, string equipo_local, string equipo_visitante)
        {
            Id = id;
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
        }
    }

    public class EventoDTO
    {
        private string _equipo_local;
        private string _equipo_visitante;
        
        public string Equipo_local { get => _equipo_local; set => _equipo_local = value; }
        public string Equipo_visitante { get => _equipo_visitante; set => _equipo_visitante = value; }

        public EventoDTO(string equipo_local, string equipo_visitante)
        {
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
        }
    }

    public class EventoFor
    {
        /*tipo de mercado y cuotas over/under*/
        private string _eq1;
        private string _eq2;
        private float _tipo;
        private float _cuota_over;
        private float _cuota_under;

        public string Eq1 { get => _eq1; set => _eq1 = value; }
        public string Eq2 { get => _eq2; set => _eq2 = value; }
        public float Tipo { get => _tipo; set => _tipo = value; }
        public float Cuota_over { get => _cuota_over; set => _cuota_over = value; }
        public float Cuota_under { get => _cuota_under; set => _cuota_under = value; }

        public EventoFor(string eq1, string eq2, float tipo, float cuota_over, float cuota_under)
        {
            Eq1 = eq1;
            Eq2 = eq2;
            Tipo = tipo;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
        }
    }
}