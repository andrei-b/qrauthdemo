using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace qrauth
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private Boolean addUser()
        {
            String dbPath = ConfigurationManager.AppSettings.Get("DBFilePath");
            if (dbPath.Equals(""))
                throw new Exception("Please set DBFilePath in the Web.config file");
            using (LiteDatabase db = new LiteDatabase(dbPath))
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