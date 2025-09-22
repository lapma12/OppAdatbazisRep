using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;
using OppAdatbazis;
using OppAdatbazis.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        
       ISqlStatements sqlStatements = new TableBooks();

        //foreach (var item in sqlStatements.GetAllBooks())
        //{
        //    var book = item.GetType().GetProperties();
        //    Console.WriteLine($"{book[0].Name}={book[0].GetValue(item)}, {book[1].Name}={book[1].GetValue(item)}");
        //}

        Console.Write("Kérem a rekord id-t: ");
        string id = Console.ReadLine();

        var book = sqlStatements.GetBookById(int.Parse(id));
        Console.WriteLine(book);





    }
}
