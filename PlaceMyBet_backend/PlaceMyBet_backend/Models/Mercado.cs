using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class Mercado
    {
        private int _id;
        private int _eventoId;
        private float _cuota_over;
        private float _cuota_under;
        private float _dinero_over;
        private float _dinero_under;
        private float _tipo; //tipo de cuota (1'5 2'5 ó 3'5)

        public int Id { get => _id; set => _id = value; }
        public int EventoId { get => _eventoId; set => _eventoId = value; }
        public float Cuota_over { get => _cuota_over; set => _cuota_over = value; }
        public float Cuota_under { get => _cuota_under; set => _cuota_under = value; }
        public float Dinero_over { get => _dinero_over; set => _dinero_over = value; }
        public float Dinero_under { get => _dinero_under; set => _dinero_under = value; }
        public float Tipo { get => _tipo; set => _tipo = value; }

        public Mercado(int id, int eventoId, float cuota_over, float cuota_under, float dinero_over, float dinero_under, float tipo)
        {
            Id = id;
            EventoId = eventoId;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
            Tipo = tipo;
        }
    }

    public class MercadoDTO
    {
        private float _cuota_over;
        private float _cuota_under;
        private float _dinero_over;
        private float _dinero_under;
        private float _tipo; //tipo de cuota (1'5 2'5 ó 3'5)

        public float Cuota_over { get => _cuota_over; set => _cuota_over = value; }
        public float Cuota_under { get => _cuota_under; set => _cuota_under = value; }
        public float Dinero_over { get => _dinero_over; set => _dinero_over = value; }
        public float Dinero_under { get => _dinero_under; set => _dinero_under = value; }
        public float Tipo { get => _tipo; set => _tipo = value; }

        public MercadoDTO(float cuota_over, float cuota_under, float dinero_over, float dinero_under, float tipo)
        {
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
            Tipo = tipo;
        }

        public MercadoDTO(float cuota_over, float cuota_under, float tipo)
        {
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Tipo = tipo;
        }
    }

    public class MercadoFor
    {
        private float _cuota_over;
        private float _cuota_under;
        private float _tipo; //tipo de cuota (1'5 2'5 ó 3'5)
        private string _emailUsuario;
        private float _importe;
        private string _tipoApuesta; //over o under

        public float Cuota_over { get => _cuota_over; set => _cuota_over = value; }
        public float Cuota_under { get => _cuota_under; set => _cuota_under = value; }
        public float Tipo { get => _tipo; set => _tipo = value; }
        public string EmailUsuario { get => _emailUsuario; set => _emailUsuario = value; }
        public float Importe { get => _importe; set => _importe = value; }
        public string TipoApuesta { get => _tipoApuesta; set => _tipoApuesta = value; }

        public MercadoFor (string emailUsuario, float cuota_over, float cuota_under, float importe, float tipo, string tipoapuesta)
        {
            EmailUsuario = emailUsuario;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Importe = importe;
            Tipo = tipo;
            TipoApuesta = tipoapuesta;
        }
    }
}