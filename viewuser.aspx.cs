using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class user : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (((ELearn.User)Session["viewUser"]) == null)
        {

            Response.Redirect("/default.aspx");

        }
        if (!IsPostBack)
        {
            Name.Text = ((ELearn.User)Session["viewUser"]).name;
            Emailaddress.Text = ((ELearn.User)Session["viewUser"]).mail;
            Username.Text = ((ELearn.User)Session["viewUser"]).username;
            Password.Text = ((ELearn.User)Session["viewUser"]).password;
        }

    }
    protected void SaveClicked(object sender, EventArgs e)
    {

        ((ELearn.User)Session["viewUser"]).update(Name.Text, Username.Text, Emailaddress.Text, Password.Text);

    }
}