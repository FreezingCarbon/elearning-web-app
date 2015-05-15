using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Collections;

public class Teacher : ELearn.User
{
    public Teacher(int userID, string username, string password, string name, string mail,
        DateTime lastSeen) : base(userID, username, password, name, mail, lastSeen) { }

    static public Teacher GetUserById(int teacherId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [User] where  id = " + teacherId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Teacher teacher = null;
        if (dataReader.Read())
        {
            if (!dataReader.GetValue(6).ToString().Equals("teacher"))
                throw new Exception("the user with the specified id is not a teacher");

            teacher = new Teacher(dataReader.GetInt32(0),
                                  dataReader.GetString(1),
                                  dataReader.GetString(2),
                                  dataReader.GetString(3),
                                  dataReader.GetString(4),
                                  dataReader.GetDateTime(5));
        }
        cmd.Connection.Close();
        return teacher;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"insert into [User] values (" 
                            + userID + ",'"
                            + username + "','"
                            + password + "','"
                            + name + "','"
                            + mail + "','"
                            + lastSeen.ToString() 
                            + "','teacher',0,null,null)";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public List<Tuple<Subject, List<ClassRoom>>> GetSubjects()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select Subject.id, Subject.levelId, Subject.title, Teaches.classId
                            from Teaches inner join Subject
                                on Teaches.subjectId = Subject.id
                            where Teaches.teacherId = " + this.userID;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Hashtable hashTable1 = new Hashtable();
        List<Tuple<Subject, List<ClassRoom>>> subjects = new List<Tuple<Subject, List<ClassRoom>>>();
        while (dataReader.Read())
        {
            int subjectId = dataReader.GetInt32(0);
            int levelId = dataReader.GetInt32(1);
            string subjectTitle = dataReader.GetString(2);
            int classId = dataReader.GetInt32(3);
            int index;
            if (hashTable1.Contains(subjectId))
                index = (int)hashTable1[subjectId];
            else
            {
                index = subjects.Count;
                hashTable1.Add(subjectId, index);
                subjects.Add(new Tuple<Subject, List<ClassRoom>>(
                                new Subject(subjectId, subjectTitle, levelId), new List<ClassRoom>()));
            }

            subjects[index].Item2.Add(new ClassRoom(classId,levelId));
        }

        return subjects;
    }

    public override List<List<string>> GetSchedule()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select Schedule.startTime, Schedule.sessionDay, Schedule.classId, Subject.title
                            from (
		                            select Teaches.subjectId, Teaches.classId
		                            from Teaches where Teaches.teacherId = " + this.userID + @"
	                            ) as teacherAssignments
	                            inner join Schedule
		                            on Schedule.classId = teacherAssignments.classId
		                                and Schedule.subjectId = teacherAssignments.subjectId
	                            inner join Subject
		                            on teacherAssignments.subjectId = Subject.id
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
            DateTime startTime = dataReader.GetDateTime(0);
            String sessionDay = dataReader.GetString(0).ToLower();
            schedule[(int)hashTable1[startTime.Hour]][(int)hashTable2[sessionDay]] = "Class: " + dataReader.GetString(2) +
                                                                                     "Subject: " + dataReader.GetString(3);
        }

        cmd.Connection.Close();
        return schedule;
    }
}