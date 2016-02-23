using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    userHandler uh;

    protected void Page_Load(object sender, EventArgs e)
    {
        uh = new userHandler();
    }

    protected void btn_create_user_click(object sender, EventArgs ev)
    {
        string mail = email.Value;
        string pass = password.Value;

        bool isUser = uh.validateUser(mail, pass);

        if(isUser)
        {
            Response.Redirect("~/account.aspx");
        }
        else
        {
            Response.Redirect(Request.RawUrl);
        }
    }
}