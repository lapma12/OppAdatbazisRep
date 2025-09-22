using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OppAdatbazis.Services
{
    internal class TableBooks : ISqlStatements
    {
        public object addNewRecord(object newBook)
        {
            Connect conn = new Connect("library");
            conn.Connection.Open();
            string sql = "INSERT INTO books (title, author, releaseDate) VALUES (@title, @author, @releaseDate)";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            var book = newBook.GetType().GetProperties();

            cmd.Parameters.AddWithValue("@title", book[0].GetValue(newBook));
            cmd.Parameters.AddWithValue("@author", book[1].GetValue(newBook));
            cmd.Parameters.AddWithValue("@releaseDate", DateTime.Now);

            cmd.ExecuteNonQuery();

            conn.Connection.Close();

            return book;
        }

        public List<object> GetAllRecords()
        {
            List<object> result = new List<object>();

            Connect conn = new Connect("library");

            conn.Connection.Open();

            string sql = "SELECT * FROM books";

            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);

            MySqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                var book = new
                {
                    Id = dr.GetInt32("id"),
                    Title = dr.GetString("title"),
                    Author = dr.GetString("author"),
                    Release = dr.GetDateTime("releaseDate"),
                }; 

                result.Add(book);
            }

            return result;



        }

        public object GetBookById(int id)
        {
            Connect conn = new Connect("library");
            conn.Connection.Open();
            string sql = "SELECT * FROM books WHERE id = @id";
            MySqlCommand cmd = new MySqlCommand(sql, conn.Connection);
            cmd.Parameters.AddWithValue("@id", id);
            MySqlDataReader dr = cmd.ExecuteReader();

            dr.Read();  
            var book = new
            {
                Id = dr.GetInt32("id"),
                Title = dr.GetString("title"),
                Author = dr.GetString("author"),
                Release = dr.GetDateTime("releaseDate")
            };
            conn.Connection.Close();
            return book;
            
        }


    }
}
