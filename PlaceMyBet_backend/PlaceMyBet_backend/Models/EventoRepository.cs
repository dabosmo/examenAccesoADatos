using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class EventoRepository : DataBase
    {
        public EventoRepository()
        {

        }

        internal List<Evento> Retrieve()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM evento ORDER BY id DESC";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                Evento evento = null;
                List<Evento> eventos = new List<Evento>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetString(1) + " " + resultado.GetString(2));
                    evento = new Evento(resultado.GetInt32(0), resultado.GetString(1), resultado.GetString(2));
                    eventos.Add(evento);
                }
                connection.Close();

                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }

        }

        internal List<EventoDTO> RetrieveDTO()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT evento.equipo_local, evento.equipo_visitante FROM evento ORDER BY id DESC";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                EventoDTO evento = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetString(1));
                    evento = new EventoDTO(resultado.GetString(0), resultado.GetString(1));
                    eventos.Add(evento);
                }
                connection.Close();

                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

        internal List<EventoFor> RetrieveById(int id)
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT evento.equipo_local, evento.equipo_visitante, mercado.tipo, mercado.cuota_over, mercado.cuota_under FROM evento INNER JOIN mercado ON mercado.evento = evento.id WHERE evento.id = @id";
            comando.Parameters.AddWithValue("@id", id);

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                List<EventoFor> eventos = new List<EventoFor>();
                EventoFor evento = null;
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetString(1) + " " + resultado.GetFloat(2) + " " + resultado.GetFloat(3) + " " + resultado.GetFloat(4));
                    evento = new EventoFor(resultado.GetString(0), resultado.GetString(1), resultado.GetFloat(2), resultado.GetFloat(3), resultado.GetFloat(4));
                    eventos.Add(evento);
                }
                connection.Close();

                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }
    }
}