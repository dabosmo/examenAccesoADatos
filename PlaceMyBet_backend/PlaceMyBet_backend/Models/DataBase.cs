using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet_backend.Models
{
    public class DataBase
    {
        public MySqlConnection db;
        public MySqlConnection Connect()
        {   
            string connectString = "server=34.219.191.133; port=3306; Database=PlaceMyBet; uid= examen; password='examen'; SslMode=none";
            MySqlConnection connection = new MySqlConnection(connectString);
            return connection;
        }
        public DataBase()
        {
            db = Connect();
        }

    }
}