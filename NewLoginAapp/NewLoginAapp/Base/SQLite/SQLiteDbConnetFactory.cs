using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace NewLoginAapp.Base.SQLite
{
     public class SQLiteDbConnetFactory : Hsj.Data.GetDbConnectFactory 
    {
        public static string sqlitePath;

        public override DbConnection GetMasterDbConn()
        {
            //客户端字符串
            //string dbPath = "Data Source =" + Environment.CurrentDirectory + "/test.db";           
            sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "UserSQLite.db");//合并路径连接字符串自动加"/"
                                                                                                                             //实例化的时候无需检查文件是否存在，SQLite 会自动判定是创建还是打开。
            return new SQLiteConnection(sqlitePath); //路径


        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.SqliteDbHelper(this);
        }

    }
}
