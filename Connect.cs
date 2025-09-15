using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppAdatbazis
{
    internal class Connect
    {
        public MySqlConnection Connection;

        private string _host;
        private string _database;
        private string _user;
        private string _password;

        private string _connectionString;

        public Connect(string database,string user,string password)
        {
            _host = "localhost";
            _database = database;
            _user = user;
            _password = password;
            _connectionString = $"Server={_host};Database={_database};User Id={_user};Password={_password};SslMode=None";

            Connection = new MySqlConnection(_connectionString);


            try
            {
                Connection.Open();
                Console.WriteLine("Sikeres csatlakozás");
                Connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba a csatlakozás során: {ex.Message}");
            }
        }
    }
}
