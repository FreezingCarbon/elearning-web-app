using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Session
{
    public int sessionID;
    public int scheduleID;
    public DateTime date;
    public string notesLink;
    public string videoLink;

    public Session(int sessionID, DateTime date, string notesLink, string videoLink, Schedule schedule)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = schedule.scheduleID;
    }

    private Session(int sessionID, DateTime date, string notesLink, string videoLink, int scheduleID)
    {
        this.sessionID = sessionID;
        this.date = date;
        this.notesLink = notesLink;
        this.videoLink = videoLink;
        this.scheduleID = scheduleID;
    }

    static public Session GetSessionById(int sessionId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Session where  id = " + sessionId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        dataReader.Read();

        Session session = new Session(Convert.ToInt32(dataReader.GetValue(0)),
                                      Convert.ToDateTime(dataReader.GetValue(2)),
                                      dataReader.GetValue(3).ToString(),
                                      dataReader.GetValue(4).ToString(),
                                      Convert.ToInt32(dataReader.GetValue(1)));
        cmd.Connection.Close();
        return session;
    }
}