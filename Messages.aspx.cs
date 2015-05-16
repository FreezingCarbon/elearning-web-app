using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Messages : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (((ELearn.User)Session["user"]) == null)
        {
            
                Response.Redirect("/default.aspx");
            
        }
        List<ELearn.User> users = new List<ELearn.User>();
        if (((String)Session["userType"]).Equals("student")) {
            users.AddRange(ClassRoom.getClassroomTeachers(((Student)Session["user"]).classRoomID));
        }
        else if (((String)Session["userType"]).Equals("teacher")) {
            users.AddRange(Teacher.getAllTeachers());
            users.AddRange(Teacher.GetTeacherStudents(((ELearn.User)Session["user"]).userID));
        }
        else if (((String)Session["userType"]).Equals("staff")) {
           users = ELearn.User.getAllUsers();
        }
        foreach (ELearn.User usr in users)
        {
            list1.Items.Add(new ListItem(usr.name, usr.userID.ToString()));
        }
    }
    protected void button1OnClick(object sender, EventArgs e)
    {
        string message = message1.Text,subject=subject1.Text;
        List<int> recivers = new List<int>();
        foreach (var index in list1.GetSelectedIndices())
        {
            var itemText = list1.Items[index].Value;
            recivers.Add(Convert.ToInt32(itemText.ToString()));
           
        }
        Message newMessage = new Message(subject,message,DateTime.Now,((ELearn.User)Session["user"]).userID,recivers);
        newMessage.sendMessage();
    }
 
}