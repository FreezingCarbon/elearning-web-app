using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Level>lvls=Level.GetAllLevels();
            List<ClassRoom> clss = ClassRoom.GetAllClassRooms();
            List<Teacher> tchrs = Teacher.getAllTeachers();
            List<ELearn.User> usrs = ELearn.User.getAllUsers();
            foreach (Level lvl in lvls)
            {
                grades.Items.Add(new ListItem(lvl.levelName, lvl.levelID.ToString()));
            }
            foreach (ClassRoom cls in clss){
                Level lvl = Level.GetLevelById(cls.levelID);
                string lname = "";
                if (lvl != null) { lname = lvl.levelName; }
                else { lname = cls.levelID.ToString(); }
                classes.Items.Add(new ListItem(lname + " - " + cls.classRoomID.ToString(), cls.classRoomID.ToString()));

            }
            foreach (Teacher tchr in tchrs)
            {
                teachers.Items.Add(new ListItem(tchr.name,tchr.userID.ToString()));
            }
            foreach (ELearn.User usr in usrs)
            {
                viewList.Items.Add(new ListItem(usr.name, usr.userID.ToString()));
            }
            
        }
    }
    protected void createGeade_Click(object sender, EventArgs e)
    {
        Level lvl = new Level(GradeName.Text);
        lvl.insert();
    }
    protected void createClass_Click(object sender, EventArgs e)
    {

        ClassRoom cls = new ClassRoom(0, Convert.ToInt32(grades.SelectedValue));
        cls.Insert();
    }
    protected void createClassSched_Click(object sender, EventArgs e)
    {
        Response.Redirect("update_schedule.aspx");
    }
    protected void createTeachSched_Click(object sender, EventArgs e)
    {
        Response.Redirect("update_schedule.aspx");
    }
    protected void createAcc_Click(object sender, EventArgs e)
    {
        if(CATypes.SelectedValue.Equals("teacher")){
            Teacher tchr = new Teacher(0, CAUN.Text,CAPW.Text, CAID.Text,  CAMAIL.Text, DateTime.Now);
            tchr.Insert();
        }
        else {
            Staff tchr = new Staff(0, CAUN.Text, CAPW.Text, CAID.Text, CAMAIL.Text, DateTime.Now,true);
            tchr.Insert();

        }
    }
    
}