using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class LigaRepository : DataBase
    {
        internal List<Liga> Retrieve()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM placemybet.leagues";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                Liga liga = null;
                List<Liga> ligas = new List<Liga>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(3) + " " + resultado.GetString(1) + " ");
                    liga = new Liga(resultado.GetString(3), resultado.GetString(1));
                    ligas.Add(liga);
                }
                connection.Close();

                return ligas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

        internal List<LigaDTO> RetrieveDTO()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM placemybet.leagues";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                LigaDTO liga = null;
                List<LigaDTO> ligas = new List<LigaDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(3) + " " + resultado.GetString(1) + " ");
                    liga = new LigaDTO(resultado.GetString(3), resultado.GetString(1));
                    ligas.Add(liga);
                }
                connection.Close();

                return ligas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }

    }
}