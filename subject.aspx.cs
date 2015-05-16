using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _class : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void createSession(object sender, EventArgs e)
    {
        MySession ses = new MySession(Convert.ToDateTime(sdate.Text), noteslink.Text, vlink.Text,
            Schedule.GetScheduleId(Convert.ToInt32(Request.QueryString["subjectId"]), 
                Convert.ToInt32(Request.QueryString["classId"])));
       ses.insert();

    }
}