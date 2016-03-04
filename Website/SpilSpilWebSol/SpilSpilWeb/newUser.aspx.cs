using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newUser : System.Web.UI.Page
{
    userHandler uha = new userHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btn_create_user_click(object sender, EventArgs e)
    {
        if (honneyPot.Text != "")
        {
            Response.Redirect("~/tba.aspx");
        }
        else
        {
            string uName = name.Text;
            string uEmail = email.Text;
            string uPass = pass.Text;
            try
            {
                string username = uha.CreateUser(uName, uEmail, uPass);
                FormsAuthentication.RedirectFromLoginPage(username, true);
            }
            catch (Exception ex)
            {
                Response.Redirect("/Error.aspx");
            }
        }
    }
}