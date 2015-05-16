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
        if(((ELearn.User)Session["user"])!=null){
            Response.Redirect("home.aspx");
        }
        List<ClassRoom> classes = ClassRoom.GetAllClassRooms();
        foreach (ClassRoom cls in classes)
        {
            Level lvl=Level.GetLevelById(cls.levelID);
           string lname="";
           if (lvl != null) { lname = lvl.levelName; }
           else { lname = cls.levelID.ToString(); }
            ListBox1.Items.Add(new ListItem(lname + " - " + cls.classRoomID.ToString(), cls.classRoomID.ToString()));
        }
        LoginButton.Focus();
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
        else { ErrorLogin.Visible = true; }
    }
    protected void RegButton_Click(object sender, EventArgs e)
    {

        Student student = new Student(0, RegUser.Text, RegPass.Text, RegName.Text, RegMail.Text, DateTime.Now, Convert.ToInt32(ListBox1.SelectedValue));
        student.Insert();
        if (student.userID != -1)
        {
            Session["user"] = student;

            Session["userType"] = "student";
            Response.Redirect("home.aspx");
        }
        else { RegisError.Visible = true; }
    }
}