using MySql.Data.MySqlClient;
using System.Data.Common;

namespace NewLoginAapp.Base.SqlServer
{
     public class SqlServerDbConnetFactory : Hsj.Data.GetDbConnectFactory 
    {
        public override DbConnection GetMasterDbConn()
        {
            return new MySqlConnection("Server=.;DataBase=HotelDB;Uid=sa;Pwd=password01!"); //路径
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.SqliteDbHelper(this);
        }

    }
}
