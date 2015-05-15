﻿using System;
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
            schedule = new Schedule(Convert.ToInt32(dataReader.GetValue(0)),
                                    dataReader.GetValue(3).ToString(),
                                    Convert.ToDateTime(dataReader.GetValue(4)),
                                    Convert.ToDateTime(dataReader.GetValue(5)),
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
}