using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        email.Attributes["type"] = "email";

        message.TextMode = TextBoxMode.MultiLine;
        message.Rows = 10;

        try
        {
            name.Value = HttpContext.Current.User.Identity.Name;
        }
        catch
        { }
    }

    public void btn_submit_clicked(object sender, EventArgs e)
    {
        if (honneyPot.Value != "")
        {
            return;
        }

        string uName = "";
        uName = name.Value;
        string uEmail = "";
        uEmail = email.Value;
        string uSubject = "";
        uSubject = subject.Value;
        string uMessage = "";
        uMessage = message.Text;

        bool sent = service.SendContactMail(uName, uEmail, uSubject, uMessage);

        if(sent)
        {
            Response.Write("<script>alert('The message has been sent!');</script>");
            Response.Redirect("#");
        }
        else
        {
            Response.Write("<script>alert('The message was lost in the mail!!');</script>");
        }
    }
}