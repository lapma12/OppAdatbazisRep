using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Adja meg az adatbázis nevét: ");
        string databaseName = Console.ReadLine();

        Console.Write("Adja meg a felhasználónevet: ");
        string username = Console.ReadLine();

        Console.Write("Adja meg a jelszót: ");
        string password = Console.ReadLine();
        string connectionString = $"Server=localhost;Database={databaseName};User Id={username};Password={password};";

        try
        {
            
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine("Sikeres csatlakozás");
            }
        }
        catch (Exception ex)
        {
            
            Console.WriteLine($"Hiba a csatlakozás során: {ex.Message}");
        }

    }
}
