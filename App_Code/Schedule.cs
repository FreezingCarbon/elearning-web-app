using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Schedule
{
    public int scheduleID;
    public int classRoomID;
    public int subjectID;
    public string day;
    public DateTime start;
    public DateTime end;

    public Schedule(int scheduleID, string day, DateTime start, DateTime end, ClassRoom classRoom, Subject subject)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        this.classRoomID = classRoom.classRoomID;
        this.subjectID = subject.subjectID;
    }

    private Schedule(int scheduleID, string day, DateTime start, DateTime end, int classRoomID, int subjectID)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        this.classRoomID = classRoomID;
        this.subjectID = subjectID;
    }

    static public Schedule GetScheduleById(int scheduleId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Schedule where  id = " + scheduleId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Schedule schedule = null;
        if(dataReader.Read())
            schedule = new Schedule(dataReader.GetInt32(0),
                                    dataReader.GetString(3),
                                    dataReader.GetDateTime(4),
                                    dataReader.GetDateTime(5),
                                    dataReader.GetInt32(2),
                                    dataReader.GetInt32(1));
        cmd.Connection.Close();
        return schedule;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Schedule values( " 
                          + scheduleID + " , " 
                          + classRoomID + " , " 
                          + subjectID + " , '" 
                          + day + "' , '" 
                          + start.ToString() + "' , "
                          + end.ToString() + "' )";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}