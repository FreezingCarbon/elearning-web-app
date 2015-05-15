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
        Session["user"] = new Student(1, "amgad", "amgadfci", "Amgad", "amgd@mail.com", DateTime.Now,new ClassRoom(2,new Level(0,"First")));
        Session["userType"] = "student";
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {

    }
}