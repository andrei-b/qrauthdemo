using System;
using System.Collections.Generic;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace qrauth
{
    public class LoginUtil
    {
        public static bool checkUserLoggedIn()
        {
            return (HttpContext.Current.User != null) && HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void logOut(HttpResponse response)
        {
            HttpContext.Current.Session.Abandon();
            System.Web.Security.FormsAuthentication.SignOut();
            response.Redirect("Default.aspx");
        }

        static  String hashPwd(String pwd)
        {
            SHA256Managed hash = new SHA256Managed();
            String h = hash.ComputeHash(Encoding.GetEncoding("ascii").GetBytes(pwd)).ToString();
            hash.Dispose();
            return h;
        }

    }
}