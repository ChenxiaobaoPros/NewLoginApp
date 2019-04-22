using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewLoginAapp.Base.SQLite
{
    public class UserSQLiteService:SQLiteBaseDbBusi<User>
    {
        //查询
        public async Task<List<User>> GetUsers()
        {
            return await DbaHelper.GetListAsync<User>();
        }
        //匹配用户
        public async Task<User> SelectUser(User user)
        {
            DbaHelper.Sql.Select.Star.From(nameof(User)).Where
                .Field_Equal_Para(nameof(User.Username), user.Username)
                .And.Field_Equal_Para(nameof(User.Password),user.Password);
            return await DbaHelper.GetEntityAsync<User>();
        }
        //查重
        public async Task<User> CnkiUser(User user)
        {

            //查重
            var _user = DbaHelper.Sql.Select.Star.From(nameof(User))
                .Where.Field_Equal_Para(nameof(User.Username), user.Username)
                .Or.Field_Equal_Para(nameof(User.Email), user.Email);
            return await DbaHelper.GetEntityAsync<User>();
        }
        //保存用户
        public async Task<long> SaveUser(User user)
        {
            var userCnki = CnkiUser(user).Result;
            if (userCnki == null)
            {
                //保存
                return await DbaHelper.InsertAsync<User>(user);
            }
            else
            {
                //
                return 0;
            }

        }

    }
}
