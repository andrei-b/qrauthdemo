using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qrauth
{
    public class User
    {
        public String userName { get; set; }
        public String password { get; set; }
        public bool isLoggedIn { get; set; }
        public string sessid { get; set; }
    }
}