using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

public class ClassRoom
{
    public int classRoomID;
    public int levelID;

    public ClassRoom(int classRoomID, Level level)
    {
        this.classRoomID = classRoomID;
        this.levelID = level.levelID;
    }

    private ClassRoom(int classRoomID, int levelID)
    {
        this.classRoomID = classRoomID;
        this.levelID = levelID;
    }

    static public ClassRoom GetClassRoomById(int classRoomID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select levelId from Class where id = " + classRoomID;
        SqlDataReader dr = cmd.ExecuteReader();
        ClassRoom classRoom = null;
        if (dr.Read())
            classRoom = new ClassRoom(classRoomID,
                                      dr.GetInt32(0));
        cmd.Connection.Close();
        return classRoom;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Class values( " + classRoomID + " , " + levelID + " )";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public List<Subject> GetSubjects()
    {
        return Level.GetSubjects(levelID);
    }

    public static List<List<string>> GetSchedule(int classRoomID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select Schedule.startTime, Schedule.sessionDay, Schedule.classId, Subject.title
                            from Schedule
	                            inner join Subject
	                            on Schedule.subjectId = Subject.id
                            where Schedule.classId = " + classRoomID + @"
                            order by Schedule.startTime asc";
        SqlDataReader dataReader = cmd.ExecuteReader();
        List<List<string>> schedule = new List<List<string>>(5);
        for (int i = 0; i < 5; ++i)
        {
            schedule.Add(new List<string>(6));
            for (int j = 0; j < 6; ++j)
                schedule[j].Add("");
        }

        Hashtable hashTable1 = new Hashtable();
        hashTable1.Add(10, 0);
        hashTable1.Add(11, 1);
        hashTable1.Add(12, 2);
        hashTable1.Add(1, 3);
        hashTable1.Add(2, 4);

        Hashtable hashTable2 = new Hashtable();
        hashTable2.Add("saturday", 0);
        hashTable2.Add("sunday", 1);
        hashTable2.Add("monday", 2);
        hashTable2.Add("tuesday", 3);
        hashTable2.Add("wednesday", 4);
        hashTable2.Add("thursday", 5);

        while (dataReader.Read())
        {
            DateTime startTime = Convert.ToDateTime(dataReader.GetValue(0));
            String sessionDay = dataReader.GetValue(0).ToString().ToLower();
            schedule[(int)hashTable1[startTime.Hour]][(int)hashTable2[sessionDay]] = "Class: " + dataReader.GetString(2) +
                                                                                      "Subject: " + dataReader.GetString(3);
        }

        cmd.Connection.Close();
        return schedule;
    }
}