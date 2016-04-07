using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Subscribe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    public void btn_subscribe_click(object sender, EventArgs e)
    {
        NewsHandler nh = new NewsHandler();
        string valid = validationCode.Value;
        string email = Request.QueryString["email"];
        nh.ValidateEmail(valid, email);
    }
}