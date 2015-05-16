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
    public TimeSpan start;
    public TimeSpan end;

    public Schedule(int scheduleID, string day, TimeSpan start, TimeSpan end, ClassRoom classRoom, Subject subject)
    {
        this.scheduleID = scheduleID;
        this.day = day;
        this.start = start;
        this.end = end;
        this.classRoomID = classRoom.classRoomID;
        this.subjectID = subject.subjectID;
    }

    private Schedule(int scheduleID, string day, TimeSpan start, TimeSpan end, int classRoomID, int subjectID)
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
            schedule = new Schedule(Convert.ToInt32(dataReader.GetValue(0)),
                                    dataReader.GetString(3),
                                    dataReader.GetTimeSpan(4),
                                    dataReader.GetTimeSpan(5),
                                    Convert.ToInt32(dataReader.GetValue(2)),
                                    Convert.ToInt32(dataReader.GetValue(1)));
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

    public static int GetScheduleId(int subjectId, int classId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select id from Schedule where subjectId = " + subjectId + "and classId = " + classId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        int scheduleId=0;
        if (dataReader.Read())
            scheduleId = Convert.ToInt32(dataReader.GetValue(0));
        cmd.Connection.Close();
        return scheduleId;
    }

    public static Schedule GetScheduleBySubjectAndClass(int subjectId, int classId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Schedule where subjectId = " + subjectId + "and classId = " + classId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Schedule schedule = null;
        if (dataReader.Read())
            schedule = new Schedule(Convert.ToInt32(dataReader.GetValue(0)),
                                    dataReader.GetString(3),
                                    dataReader.GetTimeSpan(4),
                                    dataReader.GetTimeSpan(5),
                                    Convert.ToInt32(dataReader.GetValue(2)),
                                    Convert.ToInt32(dataReader.GetValue(1)));
        cmd.Connection.Close();
        return schedule;
    }
}