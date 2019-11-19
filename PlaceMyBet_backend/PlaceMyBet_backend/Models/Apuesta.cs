using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class Apuesta
    {
        private int _id;
        private int _usuarioId;
        private int _mercadoId;
        private float _dinero;
        private string _tipo;  //over o under
        private float _cuota; //1'5 2'5 ó 3'5

        public int Id { get => _id; set => _id = value; }
        public int UsuarioId { get => _usuarioId; set => _usuarioId = value; }
        public int MercadoId { get => _mercadoId; set => _mercadoId = value; }
        public float Importe { get => _dinero; set => _dinero = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public float Cuota { get => _cuota; set => _cuota = value; }

        public Apuesta(int id, int usuarioId, int mercadoId, float importe, string tipo, float cuota)
        {
            Id = id;
            UsuarioId = usuarioId;
            MercadoId = mercadoId;
            Importe = importe;
            Tipo = tipo;
            Cuota = cuota;
        }
    }


    public class ApuestaDTO
    {
        private string _equipo_local;
        private string _equipo_visitante;
        private string _email_usuario;
        private string _mercado_tipo; //over under
        private float _cuota; // 1'5 2'5 ó 3'5
        private float _importe;

        public string Equipo_local { get => _equipo_local; set => _equipo_local = value; }
        public string Equipo_visitante { get => _equipo_visitante; set => _equipo_visitante = value; }
        public string Email_usuario { get => _email_usuario; set => _email_usuario = value; }
        public string Mercado_tipo { get => _mercado_tipo; set => _mercado_tipo = value; }
        public float Cuota { get => _cuota; set => _cuota = value; }
        public float Importe { get => _importe; set => _importe = value; }

        public ApuestaDTO(string email_usuario, string mercado_tipo, float cuota, float importe)
        {
            Email_usuario = email_usuario;
            Mercado_tipo = mercado_tipo;
            Cuota = cuota;
            Importe = importe;
        }

        public ApuestaDTO(string equipo_local, string equipo_visitante, string email_usuario, string mercado_tipo, float cuota, float importe)
        {
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
            Email_usuario = email_usuario;
            Mercado_tipo = mercado_tipo;
            Cuota = cuota;
            Importe = importe;
        }
    }
}