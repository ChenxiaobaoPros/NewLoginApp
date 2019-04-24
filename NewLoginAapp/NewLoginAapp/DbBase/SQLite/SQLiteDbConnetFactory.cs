using Mono.Data.Sqlite;
using System;
using System.Data.Common;
using System.IO;

namespace NewLoginAapp.Base.SQLite
{
     public class SQLiteDbConnetFactory : Hsj.Data.GetDbConnectFactory 
    {
        static SQLiteDbConnetFactory()
        {
            //IsIOS = true;
            switch (Xamarin.Forms.Device.RuntimePlatform)
            {
                case Xamarin.Forms.Device.iOS:
                    IsIOS = true; 
                    break;
                case Xamarin.Forms.Device.Android:
                    IsIOS = false;
                    break;
            }
        }

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
            //File.Delete(dbPath);
            bool exists = File.Exists(dbPath);
            if (!exists)
            {
                Mono.Data.Sqlite.SqliteConnection.CreateFile(dbPath);
                connection = new SqliteConnection("Data Source=" + dbPath);
                try
                {
                    //Console.WriteLine("Creating database");
                    // Need to create the database before seeding it with some data
                    #region 安全添加参数
                    //using (var addCmd = connection.CreateCommand())
                    //{
                    //    addCmd.CommandText = "CREATE TABLE [User] (Username ntext, Password ntext, Email ntext, Token ntext);";
                    //    addCmd.CommandText = "INSERT INTO [User] (Username, Password, Email,Token) VALUES (@COL1, @COL2, @COL3,@COL4)";
                    //    addCmd.CommandType = System.Data.CommandType.Text;
                    //    addCmd.Parameters.AddWithValue("@COL1", "Chenxiaobao");
                    //    addCmd.Parameters.AddWithValue("@COL2", "123456");
                    //    addCmd.Parameters.AddWithValue("@COL3", "931234253@qq.com");
                    //    addCmd.Parameters.AddWithValue("@COL4", "");
                    //    addCmd.ExecuteNonQuery();
                    //}
                    #endregion

                    #region 添加数据库
                    var commands = new[]
                    {
                        "CREATE TABLE [User] (UserID INTEGER PRIMARY KEY,Username ntext, Password ntext, Email ntext, Token ntext);",
                        "INSERT INTO [User]"+"VALUES (null,'Chenxiaobao', '123456','931234253@qq.com','')"
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
                    #endregion
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    connection.Close();
                }
            }
            else
            {
                //Console.WriteLine("Database already exists");
                // Open connection to existing database file
                connection = new SqliteConnection("Data Source=" + dbPath);
                //connection.Open();
            }

            #region 查询
            //using (var contents = connection.CreateCommand())
            //{
            //    connection.Open();
            //    contents.CommandText = "SELECT [Username], [Password] from [User]";
            //    var r = contents.ExecuteReader();
            //    Console.WriteLine("Reading data");
            //    while (r.Read())
            //        Console.WriteLine("\tKey={0}; Value={1}",
            //                          r["Username"].ToString(),
            //                          r["Password"].ToString());
            //    connection.Close();
            //}
            #endregion

            return connection;
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.SqliteDbHelper(this);
        }

    }
}
