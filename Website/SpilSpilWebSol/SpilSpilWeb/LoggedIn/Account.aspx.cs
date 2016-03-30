using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using ServiceReference1;
using System.IO;

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
        WebUser wu = null;
        try
        {
            wu = uha.GetUserByName(user);
        }
        catch (Exception ex)
        {
            string filename = Server.MapPath("/Exception.txt");
            using (StreamWriter writer = new StreamWriter(filename, true))
            {
                writer.WriteLine(DateTime.Now.ToString() + " - Exception occured when trying to retrieve data from \"" + user + "\". The exception was: \"" + ex.Message + "\"");
                writer.Flush();
                writer.Close();
            }
            throw ex;
        }

        userID.Value = wu.Id.ToString();
        userNAME.Value = wu.Name;
        userEMAIL.Value = wu.Email;
        userPASSWORD.Value = wu.Password;
        userSINCE.Value = wu.DateCreated.ToString();
    }
}