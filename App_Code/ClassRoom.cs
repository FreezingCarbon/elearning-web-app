using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

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
                                      Convert.ToInt32(dr.GetValue(0)));
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
        SqlConnection connection = DatabaseConnectionFactory.GetConnection();
        string query = @"select Schedule.startTime, Schedule.sessionDay, Schedule.classId, Subject.title
                        from Schedule
	                        inner join Subject
	                        on Schedule.subjectId = Subject.id
                        where Schedule.classId = " + classRoomID + @"
                        order by Schedule.startTime asc";


        connection.Close();

        return null;
    }
}