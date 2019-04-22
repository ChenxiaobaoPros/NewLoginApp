using System.Data.Common;


namespace NewLoginAapp.Base.PG
{
    public class PgDbConnetFactory : Hsj.Data.GetDbConnectFactory
    {
        public override DbConnection GetMasterDbConn()
        {
            return new Npgsql.NpgsqlConnection("Host=192.168.1.202;Port=15432;Username=postgres;Password=123456;Database=sxhl");
        }

        public Hsj.Data.DbHelper GetDbHelper()
        {
            return new Hsj.Data.PgSqlDbHelper(this);
        }

    }
}
