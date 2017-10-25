using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qrauth
{
    public class User
    {
        public User()
        {
            userName = "";
            password = "";
            isLoggedIn = false;
            userId = 0;
        }
        public User(int uid, String name, String pwd)
        {
            userName = name;
            password = pwd;
            isLoggedIn = false;
            userId = uid;
        }
        public int userId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool isLoggedIn { get; set; }
    }
}