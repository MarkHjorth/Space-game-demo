using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void btn_forgot_click(object sender, EventArgs e)
    {
        string passwordSt = password.Value;
        string passConfSt = passConf.Value;
        string email = Request.QueryString["email"];
        string code = Request.QueryString["code"];

        if (passwordSt == passConfSt)
        {
            service.UpdatePassword(email, code, passConfSt);
        }
        else
        {
            Response.Write("<script>alert('The new passwords must mach!');</script>");
        }
    }
}