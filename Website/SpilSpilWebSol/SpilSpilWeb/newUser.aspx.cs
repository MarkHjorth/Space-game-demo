using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            string uPass = pass.Text;
            string works = uha.CreateUser(uName, uEmail, uPass);

            //Response.Redirect("/tba.aspx");

            Response.Redirect(("~/Default.aspx/?text=" + works));
        }
    }
}