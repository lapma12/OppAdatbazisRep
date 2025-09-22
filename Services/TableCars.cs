using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppAdatbazis.Services
{
    internal class TableCars : ISqlStatements
    {
        public object addNewRecord(object newRecord)
        {
            Connect conn = new Connect("library");
            conn.Connection.Open();
            string sql = "INSERT INTO cars (brand, type, mDate) VALUES (@brand, @type, @mDate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var cars = newRecord.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@brand", cars[0].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@type", cars[1].GetValue(newRecord));
            cmd.Parameters.AddWithValue("@mDate", DateTime.Now);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            return cars;
        }

        public object deleteRecord(int id)
        {
            Connect conn = new Connect("library");

            conn.Connection.Open();
            string sql = "DELETE FROM cars WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var cars = new
            {
                Id = id
            };
            cmd.Parameters.AddWithValue("@id", cars.Id);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();

            return cars;
        }

        public List<object> GetAllRecords()
        {
            List<object> result = new List<object>();

            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "SELECT * FROM cars";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var value = new
                {
                    Id = dr.GetInt32("id"),
                    Brand = dr.GetString("brand"),
                    Type = dr.GetString("type"),
                    mDate = dr.GetDateTime("mDate")
                };

                result.Add(value);
            }
            return result;
        }

        public object GetById(int id)
        {
            Connect conn = new Connect("library");
            conn.Connection.Open();
            string sql = "SELECT * FROM cars WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();
            var value = new
            {
                Id = dr.GetInt32("id"),
                Brand = dr.GetString("brand"),
                Type = dr.GetString("type"),
                mDate = dr.GetDateTime("mDate")
            };
            conn.Connection.Close();
            return value;
        }

        public object updateRecord(int id, object updateRecord)
        {
            Connect conn = new Connect("library");
            conn.Connection.Open();
            string sql = "UPDATE cars SET brand = @brand, type = @type,mDate = @mDate WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            var cars = updateRecord.GetType().GetProperties();
            cmd.Parameters.AddWithValue("@brand", cars[0].GetValue(updateRecord));
            cmd.Parameters.AddWithValue("@type", cars[1].GetValue(updateRecord));
            cmd.Parameters.AddWithValue("@mDate", DateTime.UtcNow);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            conn.Connection.Close();
            return cars;
        }
    }
}
