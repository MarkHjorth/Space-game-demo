using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        emailAddress.Attributes["Type"] = "email";
    }

    protected void btn_subscribe_click(object sender, EventArgs e)
    {
        NewsHandler nh = new NewsHandler();

        string email = emailAddress.Value;
        nh.RegisterEmail(email);

        Response.Redirect("/Subscribe.aspx?email=" + email);
    }
}