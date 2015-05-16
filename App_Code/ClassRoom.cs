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

    public ClassRoom(int classRoomID, int levelID)
    {
        this.classRoomID = classRoomID;
        this.levelID = levelID;
    }
    public int getActiveByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "  select count(*) from [dbo].[User] where   DATEDIFF(day, [lastSeen],GETDATE() ) < 14 and [classID]=" + id.ToString();
        int cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return cnt;
    }
    public int getTotalByID(int id)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "  select count(*) from [dbo].[User] where [classID]=" + id.ToString();
        int cnt = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
        return cnt;
    }
    static public List<Student> GetAllStudentInClassRooms(int classID)
    {
        List<Student> students = new List<Student>();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [User] where classID =" + classID.ToString();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            students.Add(new Student(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), Convert.ToDateTime(dr["lastSeen"]), Convert.ToInt32(dr["classID"])));
        }
        return students;
    }
    static public List<Teacher> getClassroomTeachers(int classID)
    {
        List<Teacher> teachers = new List<Teacher>();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from( [User] inner join Teaches on teacherID=id) where Teaches.classID = " + classID.ToString();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            teachers.Add(new Teacher(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), Convert.ToDateTime(dr["lastSeen"])));
        }
        return teachers;

    }
    static public List<ClassRoom> GetAllClassRooms()
    {
        List<ClassRoom> classes = new List<ClassRoom>();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from Class";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            classes.Add(new ClassRoom(Convert.ToInt32(dr.GetValue(1)), Convert.ToInt32(dr.GetValue(0))));
        }
        return classes;
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
        cmd.CommandText = "insert into Class (levelID) OUTPUT INSERTED.id values (" + levelID + ")";
        classRoomID = Convert.ToInt32(cmd.ExecuteScalar());
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
                schedule[i].Add("");
        }

        Hashtable hashTable1 = new Hashtable();
        hashTable1.Add("10:00:00", 0);
        hashTable1.Add("11:00:00", 1);
        hashTable1.Add("12:00:00", 2);
        hashTable1.Add("01:00:00", 3);
        hashTable1.Add("02:00:00", 4);

        Hashtable hashTable2 = new Hashtable();
        hashTable2.Add("saturday", 0);
        hashTable2.Add("sunday", 1);
        hashTable2.Add("monday", 2);
        hashTable2.Add("tuesday", 3);
        hashTable2.Add("wednesday", 4);
        hashTable2.Add("thursday", 5);

        while (dataReader.Read())
        {
            String startTime = dataReader.GetValue(0).ToString();
            String sessionDay = dataReader.GetString(1).ToLower();
            //throw new Exception(startTime);
            schedule[(int)hashTable1[startTime]][(int)hashTable2[sessionDay]] = "Class: " + dataReader.GetValue(2).ToString() +
                                                                                     "Subject: " + dataReader.GetString(3);
        }

        cmd.Connection.Close();
        return schedule;
    }

    public static void assignTeacher(int classRoomID, int teacherID, int subjectID)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into Teaches values (" + teacherID + "," + subjectID + "," + classRoomID + ")";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }
}