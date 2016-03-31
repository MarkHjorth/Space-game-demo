using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class About_wizzGames : System.Web.UI.Page
{
    Administration admin = new Administration();

    protected void Page_Load(object sender, EventArgs e)
    {
        aboutMark.InnerText = admin.GetDevDescription("Mark");
        aboutDave.InnerHtml = admin.GetDevDescription("David");
    }
}