using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class MercadoRepository : DataBase
    {
        internal List<Mercado> Retrieve()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM mercado ORDER BY id DESC";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                Mercado mercado = null;
                List<Mercado> mercados = new List<Mercado>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetInt32(1) + " " + resultado.GetFloat(2) + " " + resultado.GetFloat(3) + " " + resultado.GetFloat(4) + " " + resultado.GetFloat(5) + " " + resultado.GetFloat(6));
                    mercado = new Mercado(resultado.GetInt32(0), resultado.GetInt32(1), resultado.GetFloat(2), resultado.GetFloat(3), resultado.GetFloat(4), resultado.GetFloat(5), resultado.GetFloat(6));
                    mercados.Add(mercado);
                }
                connection.Close();

                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

        internal List<MercadoDTO> RetrieveDTO()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT mercado.cuota_over, mercado.cuota_under, mercado.dinero_over, mercado.dinero_under, mercado.tipo FROM mercado ORDER BY id DESC";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                MercadoDTO mercado = null;
                List<MercadoDTO> mercados = new List<MercadoDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetFloat(0) + " " + resultado.GetFloat(1) + " " + resultado.GetFloat(2) + " " + resultado.GetFloat(3) + " " + resultado.GetFloat(4));
                    mercado = new MercadoDTO(resultado.GetFloat(0), resultado.GetFloat(1), resultado.GetFloat(2), resultado.GetFloat(3), resultado.GetFloat(4));
                    mercados.Add(mercado);
                }
                connection.Close();

                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

        internal List<MercadoFor> RetrieveById (int idMerc)
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT usuario.email, apuesta.cuota, apuesta.tipo, mercado.cuota_over, mercado.cuota_under, apuesta.dinero FROM usuario, apuesta, mercado WHERE usuario.id = apuesta.usuario AND apuesta.mercado = @idMercado";
            comando.Parameters.AddWithValue("@idMercado", idMerc);
            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                MercadoFor mercado = null;
                List<MercadoFor> mercados = new List<MercadoFor>();
                while (resultado.Read())
                {
                    mercado = new MercadoFor(resultado.GetString(0), resultado.GetFloat(3), resultado.GetFloat(4), resultado.GetFloat(5), resultado.GetFloat(1), resultado.GetString(2));
                    mercados.Add(mercado);
                }
                connection.Close();

                return mercados;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

    }
}