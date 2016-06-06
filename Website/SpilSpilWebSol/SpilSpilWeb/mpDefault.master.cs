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
        
        try
        {
            HtmlGenericControl controlTitle = (HtmlGenericControl)FindControl(Page.Title);
            controlTitle.Attributes["class"] += " active";
        }
        catch
        {
            try
            {
                HtmlGenericControl controlTitle = (HtmlGenericControl)FindControl("Home");
                controlTitle.Attributes["class"] += " active";
            }
            catch
            { }
        }

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

    private void Application_Error()
    {
        Server.Transfer("/Error.aspx");
    }
}
