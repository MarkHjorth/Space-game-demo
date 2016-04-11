using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ValidateNewUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bool validated = false;
        string code = Request.QueryString["code"];
        string email = Request.QueryString["email"];

        if (code != null && email != null)
        {
            NewsHandler nh = new NewsHandler();
            validated = nh.ValidateEmail(code, email);
        }

        if(validated)
        {
            titl.InnerHtml = "Sign up completed!";
            txt.InnerHtml = "You have sucessfully signed up on wizzGames.me!";
        }
    }
}