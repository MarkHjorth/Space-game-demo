using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class newUser : System.Web.UI.Page
{
    userHandler uha = new userHandler();

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void btn_create_user_click(object sender, EventArgs e)
    {
        if (honneyPot.Text != "")
        {
            Response.Redirect("~/tba.aspx");
        }
        else
        {
            string uName = name.Text;
            string uEmail = email.Text;
            string confEmail = confemail.Text;
            string uPass = pass.Text;
            string confPass = confpass.Text;

            //TODO -> Move to javascript
            if (!EmailsMach(email.Text, confemail.Text))
            {
                Response.Write("<script>alert('The Emails do not mach!');</script>");
                return;
            }
            if (!PasswordsMach(pass.Text, confpass.Text))
            {
                Response.Write("<script>alert('The Passwords do not mach!');</script>");
                return;
            }
            if (!PasswordIsSafe(pass.Text))
            {
                Response.Write("<script>alert('The Password is not safe! It must contain one uppercase letter, one lowercase letter and one number, and it must be 8 characters long!');</script>");
                return;
            }

            try
            {
                string username = uha.CreateUser(uName, uEmail, uPass);
                FormsAuthentication.RedirectFromLoginPage(username, true);
            }
            catch(FaultException fe)
            {
                Response.Write("<script>alert('The username or email has already been used!');</script>");
            }
            catch (Exception ex)
            {
                Response.Redirect("/Error.aspx");
            }
        }
    }

    private bool EmailsMach(string mail1, string mail2)
    {
        if (mail1 == mail2)
        {
            return true;
        }
        return false;
    }

    private bool PasswordsMach(string password1, string password2)
    {
        return (password1 == password2);
    }

    private bool PasswordIsSafe(string pass)
    {
        if (pass.Contains(name.Text) || pass.Contains(email.Text))
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