using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;

public partial class Account : System.Web.UI.Page
{
    string user;
    protected void Page_Load(object sender, EventArgs e)
    {
        user = HttpContext.Current.User.Identity.Name;

        username.InnerHtml = user;

        if (user == "2984")
        {
            Response.Redirect("~/Admin/Admin.aspx");
        }
    }
}