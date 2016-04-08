using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        message.TextMode = TextBoxMode.MultiLine;
        message.Rows = 10;
    }

    public void btn_submit_clicked(object sender, EventArgs e)
    {

    }
}