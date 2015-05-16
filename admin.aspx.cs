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
            List<Level> lvls = Level.GetAllLevels();
            List<ClassRoom> clss = ClassRoom.GetAllClassRooms();
            List<Teacher> tchrs = Teacher.getAllTeachers();
            List<ELearn.User> usrs = ELearn.User.getAllUsers();
            List<Subject> subs = Subject.getAllSubjects();
            
               // throw new Exception(lvls[(lvls.Count) - 1].levelName);
            grades.Items.Clear();

            foreach (Level lvl in lvls)
            {
                grades.Items.Add(new ListItem(lvl.levelName, lvl.levelID.ToString()));
            }
            foreach (ClassRoom cls in clss)
            {
                Level lvl = Level.GetLevelById(cls.levelID);
                string lname = "";
                if (lvl != null) { lname = lvl.levelName; }
                else { lname = cls.levelID.ToString(); }
                classes.Items.Add(new ListItem(lname + " - " + cls.classRoomID.ToString(), cls.classRoomID.ToString()));
                AssignCList.Items.Add(new ListItem(lname + " - " + cls.classRoomID.ToString(), cls.classRoomID.ToString()));

            }
            foreach (Teacher tchr in tchrs)
            {
                teachers.Items.Add(new ListItem(tchr.name, tchr.userID.ToString()));
                AssignTList.Items.Add(new ListItem(tchr.name, tchr.userID.ToString()));
            }
            foreach (ELearn.User usr in usrs)
            {
                viewList.Items.Add(new ListItem(usr.name, usr.userID.ToString()));
            }
            foreach (Subject sub in subs)
            {
                AssignSList.Items.Add(new ListItem(sub.title, sub.subjectID.ToString()));
            }
        }   
    }
    protected void createGeade_Click(object sender, EventArgs e)
    {
        Level lvl = new Level(GradeName.Text);
        lvl.insert();
        grades.Items.Add(new ListItem(GradeName.Text,lvl.levelID.ToString()));
    }
    protected void createClass_Click(object sender, EventArgs e)
    {

        ClassRoom cls = new ClassRoom(0, Convert.ToInt32(grades.SelectedValue));
        cls.Insert();
        Level lvl = Level.GetLevelById(cls.levelID);
        string lname = "";
        if (lvl != null) { lname = lvl.levelName; }
        else { lname = cls.levelID.ToString(); }
        classes.Items.Add(new ListItem(lname + " - " + cls.classRoomID.ToString(), cls.classRoomID.ToString()));

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
    protected void viewAcc_Click(object sender, EventArgs e)
    {
        Session["viewUser"] = ELearn.User.getUserByID(Convert.ToInt32(viewList.SelectedValue));
        Response.Redirect("viewuser.aspx");
    }
    protected void assignTeacher_Click(object sender, EventArgs e)
    {
        ClassRoom.assignTeacher(Convert.ToInt32(AssignCList.SelectedValue), Convert.ToInt32(AssignTList.SelectedValue), Convert.ToInt32(AssignSList.SelectedValue));
    }
    
}