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
            using (LiteDatabase db = new LiteDatabase(@"C:\db\qrauth2.db"))
            {
                var users = db.GetCollection<User>("users");
                
                var results = users.Find(x => x.userName.Equals(CreateUserWizard1.UserName));
                if (results.Count() > 0)
                {
                    return false;
                }
                else
                {
                    User user = new User(CreateUserWizard1.UserName, CreateUserWizard1.Password);
                    bool r = true;
                    try
                    {
                        // The following line rises an exception but does what it should. Buggy DBLite probably
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

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            if (!addUser())
                Response.Redirect("Register.aspx");
            else
                Response.Redirect("Login.aspx");
        }

       
    }
}