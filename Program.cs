using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;
using OppAdatbazis;

internal class Program
{
    private static void Main(string[] args)
    {
        
        Console.Write("Adja meg az adatbázis nevét: ");
        string db = Console.ReadLine();
        Console.Write("Adja meg a felhasználónevet: ");
        string fh = Console.ReadLine();
        Console.Write("Adja meg a jelszót: ");
        string pw = Console.ReadLine();
        Connect belepes = new Connect(db,fh,pw);

        Console.WriteLine(belepes);


    }
}
