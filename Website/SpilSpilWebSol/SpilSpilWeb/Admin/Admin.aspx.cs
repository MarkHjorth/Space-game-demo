using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Admin : System.Web.UI.Page
{
    private Administration admin = new Administration();

    protected void Page_Load(object sender, EventArgs e)
    {
        //Text boxes height
        markDesc.TextMode = TextBoxMode.MultiLine;
        markDesc.Height = 200;
        daveDesc.TextMode = TextBoxMode.MultiLine;
        daveDesc.Height = markDesc.Height;

        if(!IsPostBack)
        {
            //Text boxes text
            markDesc.Text = admin.GetDevDescription("Mark");
            daveDesc.Text = admin.GetDevDescription("David");
        }
    }

    protected void saveChanges_onClick(object sender, EventArgs e)
    {
        markDesc.Text = markDesc.Text;
        string mark = markDesc.Text;
        string dave = daveDesc.Text;
        bool saved = false;

        try
        {
            saved = admin.SaveChanges(mark, dave);
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
            return;
        }

        string worked;

        if(saved)
        {
            worked = "Changes saved";
        }
        else
        {
            worked = "Something went wrong! Try again!";
        }

        Response.Write("<script>alert('" + worked + "');</script>");
    }
}