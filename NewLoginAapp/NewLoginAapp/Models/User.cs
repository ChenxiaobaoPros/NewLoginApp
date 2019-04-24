using Hsj;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewLoginAapp
{
    public class User: BaseModel
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }
    }
}
