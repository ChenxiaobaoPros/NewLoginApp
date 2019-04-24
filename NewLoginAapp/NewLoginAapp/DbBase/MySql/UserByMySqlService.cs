using System;
using System.Collections.Generic;
using System.Text;

namespace NewLoginAapp.Base.MySql
{
    public class UserByMySqlService: MySqlBaseDbBusi<User>
    {
        //查询
        public List<User> GetUsers()
        {
            return DbaHelper.GetListAsync<User>().Result;
        }
    }
}
