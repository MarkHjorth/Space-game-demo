using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    userHandler uh;

    protected void Page_Load(object sender, EventArgs e)
    {
        uh = new userHandler();
    }

    protected void btn_login_click(object sender, EventArgs e)
    {
        if(honneyPot.Value != "")
        {
            Response.Redirect("~/tba.aspx");
        }

        string userName = null;
        string mail = email.Value;
        string pass = password.Value;
        string exceptionStr = "No exception was thrown!";

        try
        {
            userName = uh.validateUser(mail, pass);
        }
        catch(Exception exc)
        {
            exceptionStr = exc.Message;
            Response.Write("<script>alert('No user found!');</script>");
        }


        bool isUser = (userName != null);

        if(isUser)
        {
            FormsAuthentication.RedirectFromLoginPage(userName, true);
        }
        else
        {
            Response.Write("<script>alert('" + exceptionStr + "');</script>");
            string filename = Server.MapPath("/LoginLog.txt");
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - Failed login attempt with user \"" + userName + "\" from IP: " + Request.UserHostAddress.ToString());
                writer.Flush();
                writer.Close();
            }

            //Response.Redirect("~/error.aspx");
        }
    }
}