using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Subject
{
    public int subjectID;
    public int levelID;
    public string title;

    public Subject(int subjectID, string title, Level level)
    {
        this.subjectID = subjectID;
        this.title = title;
        this.levelID = level.levelID;
    }

    public Subject(int subjectID, string title, int levelID)
    {
        this.subjectID = subjectID;
        this.title = title;
        this.levelID = levelID;
    }

    static public Subject GetSubjectById(int subjectId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Subject where id = " + subjectId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Subject subject = null;
        if (dataReader.Read())
            subject = new Subject(Convert.ToInt32(dataReader.GetValue(0)),
                                  dataReader.GetString(2),
                                  Convert.ToInt32(dataReader.GetValue(1)));
        cmd.Connection.Close();
        return subject;
    }

    static public List<Session> GetSubjectSessions(int subjectId, int classId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select Session.id, Session.scheduleId, Session.date, Session.notesLink, Session.videoLink
                            from Session inner join Schedule
                                on Session.scheduleId = Schedule.Id
                            where Schedule.subjectId = " + subjectId + @"
                                and Schedule.classId = " + classId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<Session> sessions = new List<Session>();
        while (dataReader.Read())
        {
            //public Session(int sessionID, DateTime date, string notesLink, string videoLink, int scheduleID)
            sessions.Add(new Session(Convert.ToInt32(dataReader.GetValue(0)),
                                     Convert.ToDateTime(dataReader.GetValue(2)),
                                     dataReader.GetString(3),
                                     dataReader.GetString(4),
                                     Convert.ToInt32(dataReader.GetValue(1))));
        }
        cmd.Connection.Close();
        return sessions;
    }

    void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Subject values ( "
                          + this.subjectID + " , "
                          + this.levelID + " , '"
                          + this.title + "'  )";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}