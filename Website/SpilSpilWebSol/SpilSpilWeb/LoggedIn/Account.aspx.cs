using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class Account : System.Web.UI.Page
{
    string user;
    userHandler uha = new userHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
        user = HttpContext.Current.User.Identity.Name;
        uName.InnerHtml = user;
        if (user == "2984")
        {
            Response.Redirect("~/Admin/Admin.aspx");
        }

        FillUserData(user);
    }

    private void FillUserData(string user)
    {
        WebUser wu = uha.GetUserByName(user);

        userID.Value = wu.Id.ToString();
        userNAME.Value = wu.Name;
        userEMAIL.Value = wu.Email;
        userPASSWORD.Value = wu.Password;
        userSINCE.Value = wu.DateCreated.ToString();
    }
}