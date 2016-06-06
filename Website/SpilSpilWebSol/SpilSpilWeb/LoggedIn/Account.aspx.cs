using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.Security;
using System.Web.UI.WebControls;
using ServiceReference1;
using System.IO;
using System.Text.RegularExpressions;

public partial class Account : System.Web.UI.Page
{
    IwizzService service = new IwizzServiceClient();

    string user;
    userHandler uha = new userHandler();

    string userName = "";
    string emailAdd = "";
    string oldPass = "";
    string newPass = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        user = HttpContext.Current.User.Identity.Name;
        uName.InnerHtml = user;
        if (user == "2984")
        {
            Response.Redirect("~/Admin/Admin.aspx");
        }

        FillUserData(user);
        userChangeEMAIL.Disabled = true;
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

        userID.InnerHtml = wu.Id.ToString();
        userNAME.InnerHtml = wu.Name;
        userEMAIL.InnerHtml = wu.Email;
        //userPASSWORD.Value = wu.Password;
        userSINCE.InnerHtml = wu.DateCreated.ToString();
    }

    public void btn_update_info_click(object sender, EventArgs e)
    {
        userName = userNAME.InnerHtml;
        emailAdd = userEMAIL.InnerHtml;
        oldPass = userPASSWORD.Value;
        newPass = userChangePASSWORD.Value;

        if(PasswordIsSafe(newPass))
        {
            string u = "";
            try
            {
                if(oldPass != "" && newPass != "")
                {
                    u = service.ValidateUser(emailAdd, oldPass);
                }
                else
                {
                    Response.Write("<script>alert('You must specify both your old and a new password');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                FormsAuthentication.SignOut();
            }

            if(u != "")
            {
                bool passUpdated = service.UpdatePassword(emailAdd, oldPass, newPass);

                if(passUpdated)
                {
                    Response.Write("<script>alert('You have sucessfully updated your password');</script>");
                }
                else
                {
                    Response.Write("<script>alert('Something went horribly wrong!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('No user found');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('The Password is not safe! It must contain one uppercase letter, one lowercase letter and one number, and it must be 8 characters long!');</script>");
        }
    }

    private bool PasswordIsSafe(string pass)
    {
        if (pass.Contains(userName) || pass.Contains(emailAdd))
        {
            return false;
        }

        // at least one number, one lowercase and one uppercase letter
        // at least eight characters
        //OLD -> Regex rex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$");
        Regex rex = new Regex(@"^(?=^.{8,}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s)[-\/ 0-9a-zA-Z!@#$%¤£^&+?*()]*$");

        return rex.IsMatch(pass);
    }
}