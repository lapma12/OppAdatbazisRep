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
        //Feladat1
        //foreach (var item in sqlStatements.GetAllBooks())
        //{
        //    var book = item.GetType().GetProperties();
        //    Console.WriteLine($"{book[0].Name}={book[0].GetValue(item)}, {book[1].Name}={book[1].GetValue(item)}");
        //}

        //Feladat2
        //Console.Write("Kérem a rekord id-t: ");
        //string id = Console.ReadLine();

        //var book = sqlStatements.GetBookById(int.Parse(id));
        //Console.WriteLine(book);

        //Feladat3
        //Console.Write("Adj meg egy könyv címet: ");
        //string title = Console.ReadLine();
        //Console.Write("Adj meg hozzá a szerzőt: ");
        //string author = Console.ReadLine();

        //var newBook = new
        //{
        //    Title = title,
        //    Author = author
        //};

        //sqlStatements.addNewRecord(newBook);

        //Feladat4
        Console.Write("Kérem a törlendő rekord id-t: ");
        string id = Console.ReadLine();
        sqlStatements.deleteRecord(int.Parse(id));



    }
}
