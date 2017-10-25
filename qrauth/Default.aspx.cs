using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;

namespace qrauth
{
    public partial class Default : System.Web.UI.Page, IRequiresSessionState 
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LoginUtil.logOut(Response);
        }
    }
}