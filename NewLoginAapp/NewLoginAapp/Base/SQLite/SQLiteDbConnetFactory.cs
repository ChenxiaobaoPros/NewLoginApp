using Mono.Data.Sqlite;
using System;
using System.Data.Common;
using System.IO;

namespace NewLoginAapp.Base.SQLite
{
     public class SQLiteDbConnetFactory : Hsj.Data.GetDbConnectFactory 
    {
        public static string sqlitePath;

        public override DbConnection GetMasterDbConn()
        {
            //    //客户端字符串
            //    //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";           
            //    sqlitePath = "Data Source =" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserSQLite.db");//合并路径连接字符串自动加"/"
            //    //sqlitePath = "Data Source= UserSQLite.db";
            //    //实例化的时候无需检查文件是否存在，SQLite 会自动判定是创建还是打开。
            //    return new SqliteConnection(sqlitePath); //路径

            SqliteConnection connection;
            string dbPath = Path.Combine(
                   Environment.GetFolderPath(Environment.SpecialFolder.Personal),
                   "UserSQLite.db3");
            bool exists = File.Exists(dbPath);
            if (!exists)
            {
                //Console.WriteLine("Creating database");
                // Need to create the database before seeding it with some data
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);
                connection = new SqliteConnection("Data Source=" + dbPath);
                var commands = new[]
               {
                     "CREATE TABLE [User] (Username ntext, Password ntext, Email ntext, Token ntext);",
                     "INSERT INTO [User] ([Username], [Password], [Email], [Token]) " +
                     "VALUES ('Chenxiaobao', '123456','931234253@qq.com','')",

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
                //Console.WriteLine("Database already exists");
                // Open connection to existing database file
                connection = new SqliteConnection("Data Source=" + dbPath);
                //connection.Open();
            }

            return connection;
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.SqliteDbHelper(this);
        }

    }
}
