using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class MySession
{
    public int sessionID;
    public int scheduleID;
    public DateTime date;
    public string notesLink;
    public string videoLink;

    public MySession(int sessionID, DateTime date, string notesLink, string videoLink, Schedule schedule)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = schedule.scheduleID;
    }

    public MySession( DateTime date, string notesLink, string videoLink, int scheduleID)
    {
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = scheduleID;
    }
    public MySession(int sessionID, DateTime date, string notesLink, string videoLink, int scheduleID)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = scheduleID;
    }

    static public MySession GetSessionById(int sessionId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Session where  id = " + sessionId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        MySession session = null;
        if (dataReader.Read())
            session = new MySession(Convert.ToInt32(dataReader.GetValue(0)),
                                  dataReader.GetDateTime(2),
                                  dataReader.GetString(3),
                                  dataReader.GetString(4),
                                  Convert.ToInt32(dataReader.GetValue(1)));
        cmd.Connection.Close();
        return session;
    }

    static public List<MySession> GetSubjectSessions(int subjectId, int classId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select Session.id, Session.scheduleId, Session.[date], Session.notesLink, Session.videoLink
                            from Session inner join Schedule
                                on Session.scheduleId = Schedule.Id
                            where Schedule.subjectId = " + subjectId + @"
                                and Schedule.classId = " + classId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<MySession> sessions = new List<MySession>();
        while (dataReader.Read())
        {
            sessions.Add(new MySession(Convert.ToInt32(dataReader["id"]),
                                     Convert.ToDateTime(dataReader.GetDateTime(2)),
                                     dataReader["notesLink"].ToString(),
                                     dataReader["videoLink"].ToString(),
                                     Convert.ToInt32(dataReader["scheduleId"])));
        }
        cmd.Connection.Close();
        return sessions;
    }

    public void insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Session (scheduleId,date,notesLink,videoLink) OUTPUT INSERTED.id values ( "
                          + this.scheduleID + " , '"
                          + this.date + "' , '"
                          + this.notesLink + "','"
                          + this.videoLink + "')";
        this.sessionID = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
    }
}