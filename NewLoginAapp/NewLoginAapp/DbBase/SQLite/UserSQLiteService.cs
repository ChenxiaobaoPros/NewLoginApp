using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace NewLoginAapp.Base.SQLite
{
    public class UserSQLiteService:SQLiteBaseDbBusi<User>
    {
        //性能测试(IOS上使用HsjCore)
        public long InsertUsers()
        {
            User user = null;
            List<User> userList = new List<User>();
            int count = GetUserCount() + 1;
            for (int i = 0; i < 10000; ++i)
            {
                user = new User
                {
                    UserID = count + i,
                    Username = "第" + (count + i).ToString() + "名",
                    Email = "931234253@qq.com",
                    Password = "123456",
                    Token = i+"tokenAAAAAAAAAAAA"
                };
                userList.Add(user);
            }

            Stopwatch watch = new Stopwatch();
            DbaHelper.TimeOut = 30000;
            watch.Start();

            Insert(userList, true);
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
        public long GetEntityList()
        {
            DbaHelper.Sql.Select.Star.From(nameof(User)).
                Where.Field_GreaterEqual_Para(nameof(User.UserID), 1000)
                .And
                .Field_LessEuqal_Para(nameof(User.UserID), nameof(User.UserID) + 1, 2000)
                .Order_By.Field(nameof(User.UserID))
                .Limit(10);

            // .Where.Field_Equal_Para(nameof(HsjUser.UserName),"UserName123")
            // .Order_By.Field(nameof(HsjUser.HsjUserID)).Limit(10000);           
            Stopwatch watch = new Stopwatch();
            watch.Start();
            System.Data.DataTable myTable= DbaHelper.GetDataTable();
            //List<User> uselist = DbaHelper.GetList<User>();
            watch.Stop();
            long t = watch.ElapsedMilliseconds;
            return t;
        }
        public int GetUserCount()
        {
            DbaHelper.Sql.Select.Count("*").From(nameof(User));
            return DbaHelper.GetValue<int>();
        }
        //查询
        public List<User> GetUsers()
        {
        
            return DbaHelper.GetList<User>();
        }
        //匹配用户
        public User SelectUser(User user)
        {
            DbaHelper.Sql.Select.Star.From(nameof(User)).Where
                .Field_Equal_Para(nameof(User.Username), user.Username)
                .And.Field_Equal_Para(nameof(User.Password),user.Password).Empty();
            return DbaHelper.GetEntity<User>();
        }
        //查重
        public User CnkiUser(User user)
        {
            //查重
            DbaHelper.Sql.Select.Star.From(nameof(User))
                .Where.Field_Equal_Para(nameof(User.Username), user.Username)
                .Or.Field_Equal_Para(nameof(User.Email), user.Email);
            return DbaHelper.GetEntity<User>();
        }
        //保存用户
        public long SaveUser(User user)
        {
            var userCnki = CnkiUser(user);
            if (userCnki == null)
            {
                //保存
                DbaHelper.Insert(user);
                return DbaHelper.GetValue<int>();
            }
            else
            {
                return 0;
            }

        }

    }
}
