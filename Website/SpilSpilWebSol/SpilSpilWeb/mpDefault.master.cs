using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class mpDeafult : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string addClass = "";
        try
        {
            HtmlGenericControl controlTitle = (HtmlGenericControl)FindControl(Page.Title);
            addClass = controlTitle.Attributes["class"];
            controlTitle.Attributes["class"] += " active";
        }
        catch (Exception)
        {}

        Page.Title = Page.Title + " - wizzGames";

        adminLink.Visible = false;
        if (HttpContext.Current.User.Identity.Name != "")
        {
            string s = HttpContext.Current.User.Identity.Name;
            link_login.HRef = "~/LoggedIn/LogOut.aspx";
            btn_login.InnerHtml = "Sign out";
        }
        if (HttpContext.Current.User.Identity.Name == "2984")
        {
            adminLink.Visible = true;
        }
    }

    protected void signOut(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
    }

    protected void SignUp()
    {
        NewsHandler nh = new NewsHandler();

        string email = emailAddress.Value;
        nh.RegisterEmail(email);

        Response.Redirect("tba.aspx");
    }
}
