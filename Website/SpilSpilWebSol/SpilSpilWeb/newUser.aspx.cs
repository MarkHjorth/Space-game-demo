using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btn_create_user_click(object sender, EventArgs e)
    {
        if (honneyPot.Value != "")
        {
            Response.Redirect("~/tba.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx");
        }
    }
}