using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Specialized;

namespace qrauth
{
    public partial class Authenticate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NameValueCollection qscoll = parseQuery(Request.Url.Query);
            if (qscoll.Count == 2)
            if (LoginUtil.checkUser(qscoll.Get("l"), qscoll.Get("p")))
                    LoginUtil.
            qscoll.ToString();    
        }

        private NameValueCollection parseQuery(string s)
        {
            NameValueCollection res = new NameValueCollection();
            if (!s.StartsWith("?"))
                return res;
            s = s.Substring(1);
            string[] pars = s.Split(';'); 
            foreach (string p in pars)
            {
                string[] nv = p.Split('=');
                if (nv.Length == 2)
                {
                    res.Add(nv[0], nv[1]);
                }  
            }
            return res;
        }
    }
}