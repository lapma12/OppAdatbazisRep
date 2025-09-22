using System.Data.SqlClient;
using System;
using MySql.Data.MySqlClient;
using OppAdatbazis;
using OppAdatbazis.Services;
using System.Security.Cryptography.X509Certificates;

internal class Program
{
    private static void Main(string[] args)
    {

        ISqlStatements sqlStatements;
        Console.Write("Melyik táblát akarod használni: ");
        string choose = Console.ReadLine();
        if (choose == "book")
        {
            sqlStatements = new TableBooks();
            Console.WriteLine("======== MENÜ ========");
            Console.WriteLine("1. Összes rekord lekérdezése");
            Console.WriteLine("2. Id alapján lekérdezés");
            Console.WriteLine("3. Új rekord hozzáadása");
            Console.WriteLine("4. Rekord törlése");
            Console.WriteLine("5. Rekord frissítése");
            Console.WriteLine("======================");
            Console.WriteLine();
            Console.Write("Válassz feladatot (1-5): ");

            string feladat = Console.ReadLine();
            switch (feladat)
            {
                case "1":
                    GetAllRecordsBook();
                    break;
                case "2":
                    GetByIdBook();
                    break;
                case "3":
                    AddNewRecordBook();
                    break;
                case "4":
                    deleteRecordBook();
                    break;
                case "5":
                    updateRecordBook();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        if (choose == "cars")
        {
            sqlStatements = new TableCars();
            Console.WriteLine("======== MENÜ ========");
            Console.WriteLine("1. Összes rekord lekérdezése");
            Console.WriteLine("2. Id alapján lekérdezés");
            Console.WriteLine("3. Új rekord hozzáadása");
            Console.WriteLine("4. Rekord törlése");
            Console.WriteLine("5. Rekord frissítése");
            Console.WriteLine("======================");
            Console.WriteLine();
            Console.Write("Válassz feladatot (1-5): ");

            string feladat = Console.ReadLine();
            switch (feladat)
            {
                case "1":
                    GetAllRecords();
                    break;
                case "2":
                    GetById();
                    break;
                case "3":
                    AddNewRecord();
                    break;
                case "4":
                    deleteRecord();
                    break;
                case "5":
                    updateRecord();
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
        }
        void GetAllRecords()
        {
            foreach (var item in sqlStatements.GetAllRecords())
            {
                var cars = item.GetType().GetProperties();
                Console.WriteLine($"{cars[0].Name} = {cars[0].GetValue(item)}, {cars[1].Name} = {cars[1].GetValue(item)}, {cars[2].Name} = {cars[2].GetValue(item)} ");
            }
        }
        void GetById()
        {
            Console.Write("Kérem a rekord id-t: ");
            string id = Console.ReadLine();

            var car = sqlStatements.GetById(int.Parse(id));
            Console.WriteLine(car);
        }

        void AddNewRecord()
        {
            Console.Write("Adj meg egy autó márkát: ");
            string brand = Console.ReadLine();
            Console.Write("Adj meg hozzá a típust: ");
            string type = Console.ReadLine();

            var newCar = new
            {
                Brand = brand,
                Type = type
            };

            sqlStatements.addNewRecord(newCar);
        }
        void deleteRecord()
        {
            Console.Write("Kérem a törlendő rekord id-t: ");
            string id = Console.ReadLine();
            sqlStatements.deleteRecord(int.Parse(id));
        }

        void updateRecord()
        {
            Console.Write("Kérem a módosítandó rekord id-t: ");
            string id = Console.ReadLine();
            Console.Write("Adj meg egy autó márkát: ");
            string brand = Console.ReadLine();
            Console.Write("Adj meg hozzá a típust: ");
            string type = Console.ReadLine();
            var updateCar = new
            {
                Brand = brand,
                Type = type
            };

            sqlStatements.updateRecord(int.Parse(id), updateCar);
            Console.WriteLine("Sikeres rekord frissítés!");
        }






        void GetAllRecordsBook()
        {
            foreach (var item in sqlStatements.GetAllRecords())
            {
                var book = item.GetType().GetProperties();
                Console.WriteLine($"{book[0].Name}={book[0].GetValue(item)}, {book[1].Name}={book[1].GetValue(item)}");
            }
        }
        void GetByIdBook()
        {
            Console.Write("Kérem a rekord id-t: ");
            string id = Console.ReadLine();

            var book = sqlStatements.GetById(int.Parse(id));
            Console.WriteLine(book);
        }
        void AddNewRecordBook()
        {
            Console.Write("Adj meg egy könyv címet: ");
            string title = Console.ReadLine();
            Console.Write("Adj meg hozzá a szerzőt: ");
            string author = Console.ReadLine();

            var newBook = new
            {
                Title = title,
                Author = author
            };

            sqlStatements.addNewRecord(newBook);
        }
        void deleteRecordBook()
        {
            Console.Write("Kérem a törlendő rekord id-t: ");
            string id = Console.ReadLine();
            sqlStatements.deleteRecord(int.Parse(id));
        }
        void updateRecordBook()
        {
            Console.Write("Kérem a módosítandó rekord id-t: ");
            string id = Console.ReadLine();
            Console.Write("Adj meg egy könyv címet: ");
            string title = Console.ReadLine();
            Console.Write("Adj meg hozzá a szerzőt: ");
            string author = Console.ReadLine();
            var updateBook = new
            {
                Title = title,
                Author = author
            };

            sqlStatements.updateRecord(int.Parse(id), updateBook);
            Console.WriteLine("Sikeres rekord frissítés!");
        }
    }   
}
