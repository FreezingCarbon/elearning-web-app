using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 
public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
   
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        ELearn.User usr = ELearn.User.loginUser(userName_login.Text, passwordLogin.Text);
        if (usr != null)
        {
            Session["user"] = usr;
            if (usr is Student)
            {
                Session["userType"] = "student";
            }
            else if (usr is Staff)
            {
                Session["userType"] = "staff";
            }
            else if (usr is Teacher)
            {
                Session["userType"] = "teacher";
            }
            Response.Redirect("home.aspx");
        }
        else {  }
    }
}