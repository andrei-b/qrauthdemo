using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace qrauth
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        private Boolean addUser()
        {
            using (LiteDatabase db = new LiteDatabase(@"C:\db\qrauth.db"))
            {
                var users = db.GetCollection<User>("users");
                
                var results = users.Find(x => x.userName.Equals(CreateUserWizard1.UserName));
                if (results.Count() > 0)
                {
                    return false;
                }
                else
                {
                    User user = new User
                    {
                        userName = CreateUserWizard1.UserName,
                        password = CreateUserWizard1.Password,
                        isLoggedIn = false,
                        sessid = ""
                    };
                    if (users.Insert(user))
                        return true;
                    else
                        return false;
                }
            }
        }

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            if (!addUser())
                Label1.Text = "The user is not registered!";
            else
                Response.Redirect("Login.aspx");
        }
    }
}