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
        bool validated = false;
        string code = Request.QueryString["code"];
        string email = Request.QueryString["email"];

        if(code != null && email != null)
        {
            NewsHandler nh = new NewsHandler();
            validated = nh.ValidateEmail(code, email);
        }

    }
}