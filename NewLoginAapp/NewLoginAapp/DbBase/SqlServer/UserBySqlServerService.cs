using System.Collections.Generic;


namespace NewLoginAapp.Base.SqlServer
{
    public class UserBySqlServerService: SqlServerBaseDbBusi<User>
    {
        //查询
        public List<User> GetUsers()
        {
            return DbaHelper.GetListAsync<User>().Result;
        }
    }
}
