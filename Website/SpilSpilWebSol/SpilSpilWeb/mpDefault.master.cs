using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class mpDeafuæt : System.Web.UI.MasterPage
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
        catch (Exception ex)
        {
            
        }
        Page.Title = Page.Title + " - spilSpillet";
    }

    
}
