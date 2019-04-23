using Mono.Data.Sqlite;
using NewLoginAapp.Base.SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
//using System.Data.SQLite;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace NewLoginAapp
{
    public partial class App : Application
    {

        public static bool isUserLogIn {get;set;}
        public App()
        {
            InitializeComponent();
            //DoSomeDataAccess();
            if (!isUserLogIn)
            {
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainPage = new NavigationPage(new MainPage());
            }
        }
        public static SqliteConnection connection;
        public static void DoSomeDataAccess()
        {
            // determine the path for the database file
            string dbPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                "adodemo.db3");

            bool exists = File.Exists(dbPath);

            if (!exists)
            {
                Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);
                connection = new SqliteConnection("Data Source=" + dbPath);

                var commands = new[]
                {
                     "CREATE TABLE [Items] (_id ntext, Symbol ntext);",
                     "INSERT INTO [Items] ([_id], [Symbol]) VALUES ('1', 'AAPL')",
                     "INSERT INTO [Items] ([_id], [Symbol]) VALUES ('2', 'GOOG')",
                     "INSERT INTO [Items] ([_id], [Symbol]) VALUES ('3', 'MSFT')"
                };
                // Open the database connection and create table with data
                connection.Open();
                foreach (var command in commands)
                {
                    using (var c = connection.CreateCommand())
                    {
                        c.CommandText = command;
                        var rowcount = c.ExecuteNonQuery();
                        Console.WriteLine("\tExecuted " + command);
                    }
                }
            }
            else
            {
                Console.WriteLine("Database already exists");
                // Open connection to existing database file
                connection = new SqliteConnection("Data Source=" + dbPath);
                connection.Open();
            }

            // query the database to prove data was inserted!
            using (var contents = connection.CreateCommand())
            {
                contents.CommandText = "SELECT [_id], [Symbol] from [Items]";
                var r = contents.ExecuteReader();
                Console.WriteLine("Reading data");
                while (r.Read())
                    Console.WriteLine("\tKey={0}; Value={1}",
                                      r["_id"].ToString(),
                                      r["Symbol"].ToString());
            }
            connection.Close();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
