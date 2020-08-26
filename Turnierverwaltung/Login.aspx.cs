using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Turnierverwaltung
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["do"] == "logout")
            {
                Session.Clear();
                Response.Redirect("~/Default.aspx",true);
            }
        }

        protected void Login_Authenticate(object sender, AuthenticateEventArgs e)
        {
            if( LoginMaske.UserName == "user" && LoginMaske.Password == "user")
            {
                LblMsg.Visible = false;
                Session["auth"] = true;
                Response.Redirect("~/Default.aspx");
            }
            else if(LoginMaske.UserName == "admin" && LoginMaske.Password == "admin")
            {
                LblMsg.Visible = false;
                Session["auth"] = true;
                Response.Redirect("~/Default.aspx");
            }
            else
            {
                //Access denied!
                Session["auth"] = false;
                LblMsg.Visible = true;
            }
        }
    }
}