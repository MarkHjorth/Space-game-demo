using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_Edit2984 : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        desc.TextMode = TextBoxMode.MultiLine;
        desc.Rows = 10;

        if (!IsPostBack)
        {
            string des = service.GetDevDescription("2984").Replace("<br />", Environment.NewLine);
            desc.Text = des;
        }
    }

    public void saveChanges_onClick(object sender, EventArgs e)
    {
        string description = desc.Text.Replace(Environment.NewLine, "<br />");
        service.SaveDevDescriptions("2984", description);
    }
}