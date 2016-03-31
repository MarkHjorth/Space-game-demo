using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class Admin_EditWizzgames : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        markDesc.TextMode = TextBoxMode.MultiLine;
        daveDesc.TextMode = TextBoxMode.MultiLine;
        markDesc.Rows = 10;
        daveDesc.Rows = 10;

        if (!IsPostBack)
        {
            markDesc.Text = service.GetDevDescription("Mark");
            daveDesc.Text = service.GetDevDescription("David");
        }
    }

    public void saveChanges_onClick(object sender, EventArgs e)
    {
        service.SaveDevDescriptions("Mark", markDesc.Text);
        service.SaveDevDescriptions("David", daveDesc.Text);
    }
}