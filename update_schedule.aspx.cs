using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class update_schedule : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((string)Session["schType"]==null) Response.Redirect("Default.aspx");
        if (!IsPostBack)
        {
            List<List<string>> schedule = null;
            if (((string)Session["schType"]).Equals("class"))
                schedule = ClassRoom.GetSchedule(Convert.ToInt32(((string)Session["classID"])));
            
            List<Subject> subs = Subject.getAllSubjects();
            List<Teacher> teachs = ClassRoom.getClassroomTeachers(Convert.ToInt32(Session["classID"]));
            foreach (Subject sub in subs)
            {
                subjects.Items.Add(new ListItem(sub.title, sub.subjectID.ToString()));

            }
            foreach (Teacher tchr in teachs)
            {
                teachers.Items.Add(new ListItem(tchr.name, tchr.userID.ToString()));

            }
            for (int i = 0; i < schedule.Count; i++)
            {
                string slot = "";
                switch (i)
                {
                    case 0:
                        slot = "10 - 11";
                        break;
                    case 1:
                        slot = "11 - 12";
                        break;
                    case 2:
                        slot = "12 - 1";
                        break;
                    case 3:
                        slot = "1 - 2";
                        break;
                    case 4:
                        slot = "2 - 3";
                        break;
                    default:
                        slot = "";
                        break;
                }
                for (int j = 0; j < 6; j++)
                {
                    string day = "";
                
                    switch (j)
                    {
                        case 0:
                            day = "saturday";
                            break;
                        case 1:
                            day = "sunday";
                            break;
                        case 2:
                            day = "monday";
                            break;
                        case 3:
                            day = "tuesday";
                            break;
                        case 4:
                            day = "wednesday";
                            break;
                        case 5:
                            day = "thursday";
                            break;
                        default:
                            day = "";
                            break;
                    }
                    
                    ListItem item=new ListItem(day + " " + slot, "" + ((i * 5) + j));
                    if ((schedule[i])[j] == "")
                    {
                        slotes.Items.Add(item);
                    }
                    else { removed.Items.Add(item); }
                    
                }


            }
        }

    }
    class StartAndEnd{
        public TimeSpan s, e;
        public StartAndEnd(TimeSpan s1, TimeSpan e1)
        {
            e = e1;
            s = s1;
        }
    }
    private StartAndEnd getTime(int key)
    {
        StartAndEnd slot = null;
        switch (key/5)
        {
            case 0:
                slot = new StartAndEnd(new TimeSpan(10, 0, 0), new TimeSpan(11, 0, 0));
                break;
            case 1:
                slot = new StartAndEnd(new TimeSpan(11, 0, 0), new TimeSpan(12, 0, 0));
                break;
            case 2:
                slot = new StartAndEnd(new TimeSpan(12, 0, 0), new TimeSpan(1, 0, 0));
                break;
            case 3:
                slot = new StartAndEnd(new TimeSpan(1, 0, 0), new TimeSpan(2, 0, 0));
                break;
            case 4:
                slot = new StartAndEnd(new TimeSpan(2, 0, 0), new TimeSpan(3, 0, 0));
                break;
            default:
                slot = null;
                break;
        }
        return slot;
    }
    private String getDay(int key)
    {
        string day = "";
        switch (key%5)
        {
            case 0:
                day = "saturday";
                break;
            case 1:
                day = "sunday";
                break;
            case 2:
                day = "monday";
                break;
            case 3:
                day = "tuesday";
                break;
            case 4:
                day = "wednesday";
                break;
            case 5:
                day = "thursday";
                break;
            default:
                day = "";
                break;
        }
        return day;
    }
    protected void add_Click(object sender, EventArgs e)
    {
        int key=Convert.ToInt32(slotes.SelectedValue);
        Schedule sc = new Schedule(0, getDay(key), getTime(key).s, getTime(key).e, Convert.ToInt32(Session["classID"]), Convert.ToInt32(subjects.SelectedValue));
    sc.Insert();
    removed.Items.Add(new ListItem(slotes.SelectedItem.Text,slotes.SelectedItem.Value));
    slotes.Items.RemoveAt(slotes.SelectedIndex);
    }
    protected void remove_Click(object sender, EventArgs e)
    {
        int key = Convert.ToInt32(removed.SelectedValue);
        Schedule.removeScheduleId(Convert.ToInt32(Session["classID"]), getTime(key).s,getDay(key));
     //   throw new Exception(getTime(key).s.ToString() +" "+ getDay(key));
       slotes.Items.Add(new ListItem(removed.SelectedItem.Text,removed.SelectedValue));
        removed.Items.RemoveAt(removed.SelectedIndex);
    }       
}