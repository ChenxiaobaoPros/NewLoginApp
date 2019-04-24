using MySql.Data.MySqlClient;
using System.Data.Common;


namespace NewLoginAapp.Base.MySql
{
    public class MySqlDbConnetFactory : Hsj.Data.GetDbConnectFactory
    {
        public override DbConnection GetMasterDbConn()
        {
            return new MySqlConnection("Data Source = 127.0.0.1; Database = 你的数据库名; User ID = 用户名; Password = 密码");
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.PgSqlDbHelper(this);
        }

    }
}
