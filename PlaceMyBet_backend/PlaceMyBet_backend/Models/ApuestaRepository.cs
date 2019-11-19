using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class ApuestaRepository : DataBase
    {
        internal List<Apuesta> Retrieve()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT * FROM Apuesta ORDER BY id DESC";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                Apuesta apuesta = null;
                List<Apuesta> apuestas = new List<Apuesta>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetInt32(0) + " " + resultado.GetInt32(1) + " " + resultado.GetInt32(2) + " " + resultado.GetFloat(3) + " " + resultado.GetString(4) + " " + resultado.GetFloat(5));
                    apuesta = new Apuesta(resultado.GetInt32(0), resultado.GetInt32(1), resultado.GetInt32(2), resultado.GetFloat(3), resultado.GetString(4), resultado.GetFloat(5));
                    apuestas.Add(apuesta);
                }
                connection.Close();

                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }
        
        internal List<ApuestaDTO> RetrieveDTO()
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT usuario.email, apuesta.tipo, apuesta.cuota, apuesta.dinero FROM placemybet.Apuesta, placemybet.usuario WHERE usuario.id = apuesta.usuario";

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                ApuestaDTO apuesta = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (resultado.Read())
                {
                    Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetString(1) + " " + resultado.GetFloat(2) + " " + resultado.GetFloat(3));
                    apuesta = new ApuestaDTO(resultado.GetString(0), resultado.GetString(1), resultado.GetFloat(2), resultado.GetFloat(3));
                    apuestas.Add(apuesta);
                }
                connection.Close();

                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }
        /*** Ejercicio 2 ***/
        internal List<ApuestaExamen> RetrieveByIdMercado(int idMerc)
        {
            Debug.WriteLine("ENTRO EN ESTE MÉTODO");

            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT apuesta.tipo, apuesta.cuota, apuesta.dinero FROM placemybet.Apuesta, placemybet.mercado WHERE mercado.id = @idMerc AND apuesta.mercado = mercado.id ";
            comando.Parameters.AddWithValue("@idMerc", idMerc);

            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                ApuestaExamen apuesta = null;
                List<ApuestaExamen> apuestas = new List<ApuestaExamen>();
                while (resultado.Read())
                {
                    if(resultado.GetFloat(2) >= 100)
                    {
                        Debug.WriteLine("Recupero " + resultado.GetFloat(2) + " y " + (resultado.GetFloat(2) >= 100f));
                        //Debug.WriteLine("Recuperado: " + resultado.GetString(0) + " " + resultado.GetFloat(1) + " " + resultado.GetFloat(2) + " ");
                        apuesta = new ApuestaExamen(resultado.GetString(0), resultado.GetFloat(1), resultado.GetFloat(2));
                        apuestas.Add(apuesta);
                    }
                    
                }
                connection.Close();

                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }
        /*** Fin ejercicio 2 ***/
        internal List<ApuestaDTO> RetrieveByEmail(string email)
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand comando = connection.CreateCommand();
            comando.CommandText = "SELECT evento.equipo_local, evento.equipo_visitante, usuario.email, apuesta.cuota, apuesta.tipo, apuesta.dinero, mercado.id FROM usuario, evento, apuesta, mercado WHERE usuario.id = apuesta.usuario AND mercado.id = apuesta.mercado AND usuario.email = @email AND mercado.evento = evento.id" ;
            comando.Parameters.AddWithValue("@email", email);
            Debug.WriteLine(email);
            try
            {
                connection.Open();
                MySqlDataReader resultado = comando.ExecuteReader();
                ApuestaDTO apuesta = null;
                List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
                while (resultado.Read())
                {
                    
                    apuesta = new ApuestaDTO(resultado.GetString(0), resultado.GetString(1), resultado.GetString(2), resultado.GetString(4), resultado.GetFloat(3), resultado.GetFloat(5));
                    apuestas.Add(apuesta);
                }
                connection.Close();

                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error al realizar la conexión");
                return null;
            }
        }


        internal void Save(Apuesta apuesta)
        {
            CultureInfo culInfo = new CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "INSERT INTO apuesta (usuario, mercado, dinero, tipo, cuota) VALUES('" + apuesta.UsuarioId + "','" + apuesta.MercadoId + "','" + apuesta.Importe + "', '" + apuesta.Tipo + "', '" + apuesta.Cuota + "');";
            Debug.Write("Comando " + command.CommandText);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();

            }
            catch (MySqlException e)
            {
                Debug.Write("No se pudo realizar la conexión");
            }
        }

        internal void Update(int idMerc)
        {
            DataBase dato = new DataBase();
            MySqlConnection connection = dato.db;
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "select apuesta.tipo, apuesta.dinero, apuesta.cuota, apuesta.usuario, mercado.evento, mercado.cuota_over, mercado.cuota_under, mercado.dinero_over, mercado.dinero_under, mercado.tipo, usuario.id FROM apuesta, mercado, usuario WHERE apuesta.id = (SELECT MAX(id) FROM apuesta) AND mercado.id = @idMerc AND usuario.id = apuesta.usuario ";
            command.Parameters.AddWithValue("@idMerc", idMerc);
            


            connection.Open();
            MySqlDataReader resultado = command.ExecuteReader();

            resultado.Read();

            //Datos necesarios para actualizar los mercados (en la consulta no deberia ser la id maxima de la apuesta ya que varios usuarios podrian hacer apuestas a la vez ¿como solucionar?

        
            string tipo = resultado.GetString(0);  // tipo de la apuesta (over/under)
            Debug.WriteLine("-------------" + tipo + "----------------" + resultado.GetString(0));
            float tipoCuota = resultado.GetFloat(9);  //Tipo de mercado (1'5 2'5 ó 3'5)
            int idEvento = resultado.GetInt32(6);
            float cuotaApuesta = resultado.GetFloat(2); // (1'5 2'5 ó 3'5)
            float importe = resultado.GetFloat(1);
            float total_over = resultado.GetFloat(7) + importe;
            Debug.WriteLine("--------------------" + importe + " " + resultado.GetFloat(8));
            float total_under = resultado.GetFloat(8) + importe;
            float probabilidad_over = total_over / (total_over + total_under);
            float probabilidad_under = total_under / (total_over + total_under);
            float cuota_over = (1 / probabilidad_over) * 95 / 100;
            float cuota_under = (1 / probabilidad_under) * 95 / 100;

            connection.Close();
        

            CultureInfo culInfo = new CultureInfo("es-ES");

            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            if (tipo.Equals("under"))
            {

                command.CommandText = "UPDATE mercado SET dinero_under='" + total_under + "', cuota_under='" + cuota_under + "' WHERE mercado.id=" + idMerc + ";";
                Debug.Write("Comando " + command.CommandText);

            }
            else if (tipo.Equals("over"))
            {

                command.CommandText = "UPDATE mercado SET dinero_over='" + total_over + "', cuota_over='" + cuota_over + "' WHERE mercado.id=" + idMerc + ";";
                Debug.Write("Comando " + command.CommandText);



            }
            try
            {
                connection.Open();
                int filas = command.ExecuteNonQuery();
                if (filas > 0)
                {
                    Debug.Write("Todo correcto");
                }
                else
                {
                    Debug.Write("Algun dato incorrecto");
                }



            }
            catch (MySqlException e)
            {
                Debug.Write("No se puedo realizar la conexión");
            }

            connection.Close();
        }
    }
}
