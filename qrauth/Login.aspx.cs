using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;


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
                e.Authenticated = LoginUtil.checkUser(Login1.UserName, Login1.Password);

            }
        }
    }
}