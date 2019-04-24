using System.Collections.Generic;


namespace NewLoginAapp.Base.PG 
{
    public class UserByPgService: PgBaseDbBusi<User>
    {
        //查询
        public List<User> GetUsers()
        {
            return DbaHelper.GetListAsync<User>().Result;
        }
    }
}
