using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ForgotPassword : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        email.Attributes["type"] = "email";
    }

    public void btn_forgot_click(object sender, EventArgs e)
    {
        if(honneyPot.Value != "")
        {
            Response.Redirect("~/tba.aspx");
        }

        string mail = email.Value;

        bool worked = service.ForgotPassword(mail);

        if(worked)
        {
            Response.Write("<script>alert('An email was sent to the specified address');</script>");
        }
        else
        {
            Response.Write("<script>alert('Something went wrong');</script>");
        }
    }
}