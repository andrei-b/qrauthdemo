using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;
using System.Security.Cryptography;
using System.Text;
using LiteDB;
using System.Configuration;

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

        static public bool checkUser(String name, String pwd)
        {
            String dbPath = ConfigurationManager.AppSettings.Get("DBFilePath");
            if (dbPath.Equals(""))
                throw new Exception("Please set DBFilePath in the Web.config file");
            using (var db = new LiteDatabase(dbPath))
            {
                LiteCollection<User> users = db.GetCollection<User>("users");
                users.EnsureIndex(x => x.userId); 
                IEnumerable<User> results = null;
                try
                {
                    results = users.Find(x => x.userName.Equals(name));
                }
                catch(InvalidCastException e)
                {

                }
                IEnumerator<User> en = null; 
                if ((en = results.GetEnumerator()).MoveNext())
                {
                    if (en.Current.password.Equals(pwd))
                    {
                        db.Dispose();
                        return true;
                    }
                    else
                    {
                        db.Dispose();
                        return false;
                    }
                }
                else
                {
                    db.Dispose();
                    return false;
                }
            }
        }

        static public bool addUser(String name, String pwd)
        {
            String dbPath = ConfigurationManager.AppSettings.Get("DBFilePath");
            if (dbPath.Equals(""))
                throw new Exception("Please set DBFilePath in the Web.config file");
            using (LiteDatabase db = new LiteDatabase(dbPath))
            {
                LiteCollection<User> users = db.GetCollection<User>("users");
                users.EnsureIndex(x => x.userId);
                IEnumerable<User> results = users.Find(x => x.userName.Equals(name));
                if (results.GetEnumerator().MoveNext())
                {
                    return false;
                }
                else
                {
                    
                    Int32 maxid = users.Max();
                    User user = new User(maxid + (new Random()).Next(16), name, pwd);
                    bool r = true;
                    try
                    {
                        // The following line raises an exception but still does what it should do. Buggy DBLite probably
                        r = users.Insert(user);
                    }
                    catch (InvalidCastException e)
                    {
                    }
                    finally
                    {
                        db.Dispose();
                    }
                    return r;
                }
            }
        }

        static public int newLoginSession()
        {
            String dbPath = ConfigurationManager.AppSettings.Get("DBFilePath");
            if (dbPath.Equals(""))
                throw new Exception("Please set DBFilePath in the Web.config file");
            using (LiteDatabase db = new LiteDatabase(dbPath))
            {
                LiteCollection<UserSession> logins = db.GetCollection<UserSession>("sessions");
                logins.EnsureIndex(x => x.userSessionId);
                Int32 maxid = logins.Max();
                UserSession login = new UserSession(maxid + (new Random()).Next(16));
                try
                {
                    // The following line raises an exception but still does what it should do. Buggy DBLite probably
                    logins.Insert(login);

                }
                catch (InvalidCastException e)
                {
                }
                finally
                {
                    db.Dispose();
                }
                return login.userSessionId;
            }
        }
        public static bool isUserLogged(HttpSessionState session)
        {
            return true;
        }
    }
}