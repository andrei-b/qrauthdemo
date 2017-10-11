using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LiteDB;

namespace qrauth
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if ((Login1.UserName.Equals("andrei")&&(Login1.Password.Equals("letmein"))))
            {
                e.Authenticated = true;
            }
            else
            {
                using (var db = new LiteDatabase(@"C:\db\qrauth.db"))
                {
                    var users = db.GetCollection<User>("users");
                    var results = users.Find(x => x.userName.Equals(Login1.UserName));
                    if (results.Count() > 0)
                    {
                        if (results.First().password.Equals(Login1.Password))
                            e.Authenticated = true;
                        else
                            e.Authenticated = false;
                    }
                    else
                        e.Authenticated = false;
                    db.Dispose(); 
                }
            }
        }
    }
}