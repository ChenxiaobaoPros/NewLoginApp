using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;

namespace NewLoginAapp.Base.SQLite
{
     public class SQLiteDbConnetFactory : Hsj.Data.GetDbConnectFactory 
    {
        public override DbConnection GetMasterDbConn()
        {
            string sqlitePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"UserSQLite.db");//合并路径连接字符串自动加"/"
            return new SQLiteConnection(sqlitePath);//路径
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.SqliteDbHelper(this);
        }

    }
}
