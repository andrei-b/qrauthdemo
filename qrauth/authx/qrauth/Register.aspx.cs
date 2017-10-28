using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using System.Web.SessionState;

namespace qrauth
{
    public partial class Register : System.Web.UI.Page, IRequiresSessionState
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
        }

        protected void CreateUserWizard1_CreatingUser(object sender, LoginCancelEventArgs e)
        {
            if (!LoginUtil.addUser(CreateUserWizard1.UserName, CreateUserWizard1.Password))
                Response.Redirect("Register.aspx");
            else
                Response.Redirect("Login.aspx");
        }

       
    }
}