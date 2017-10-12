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
            sessid = "";
        }
        public User(String name, String pwd)
        {
            userName = name;
            password = pwd;
            isLoggedIn = false;
            sessid = "";
        }
        public String userName { get; set; }
        public String password { get; set; }
        public bool isLoggedIn { get; set; }
        public string sessid { get; set; }
    }
}