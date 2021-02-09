using System;
using System.Collections.Generic;
using System.Text;
using AltV.Net;
using MySql.Data.MySqlClient;

namespace ProjectHome_001.Database
{
    class OwnDatabase
    {
        public static OwnDatabase DB { get; set; }
        private string ConnectionString { get; set; }
        public MySqlConnection Connection { get; set; }

        public OwnDatabase()
        {
            ConnectionString = "SERVER=localhost;DATABASE=ProjectHome;UID=ProjectHome;PASSWORD=SliBknot19;";
            Connection = new MySqlConnection(ConnectionString);
            DB = this;
            CreateTables();
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }

        public void CreateTables()
        {
            try
            {
                Connection.Open();
                MySqlCommand command = Connection.CreateCommand();

                command.CommandText = "CREATE TABLE IF NOT EXISTS users (" + "id INT(6) UNSIGNED AUTO_INCREMENT PRIMARY KEY," + "name VARCHAR(40) NOT NULL," + "cash INT(12) NOT NULL DEFAULT 0)";
                command.ExecuteNonQuery();
                Connection.Close();

            }
                catch (Exception e)
             {
                Alt.Log("CheckTables: " + e.StackTrace);
                Alt.Log("CheckTables: " + e.Message);
             }
        }   

    }
}
