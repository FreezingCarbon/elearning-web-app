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
        DateTime lastSeen)
        : base(userID, username, password, name, mail, lastSeen) { }

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
            if (!dataReader["userType"].ToString().Equals("teacher"))
                throw new Exception("the user with the specified id is not a teacher");

            teacher = new Teacher(Convert.ToInt32(dataReader["id"]),
                                  dataReader["username"].ToString(),
                                  dataReader["password"].ToString(),
                                  dataReader["name"].ToString(),
                                  dataReader["mail"].ToString(),
                                  Convert.ToDateTime(dataReader["lastSeen"]));
        }
        cmd.Connection.Close();
        return teacher;
    }

    static public Teacher GetTeacherBySubjectAndClass(int subjectId, int classId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = @"select [User].id, [User].username, [User].password, [User].name, [User].mail, [User].lastSeen
                            from [User] inner join Teaches
                                on [User].id = Teaches.teacherId
                            where Teaches.subjectId = " + subjectId + @"
                                and Teaches.classId = " + classId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Teacher teacher = null;
        if (dataReader.Read())
        {
            teacher = new Teacher(Convert.ToInt32(dataReader.GetValue(0)),
                                  dataReader.GetString(1),
                                  dataReader.GetString(2),
                                  dataReader.GetString(3),
                                  dataReader.GetString(4),
                                  dataReader.GetDateTime(5));
        }
        cmd.Connection.Close();
        return teacher;
    }

    public override void update(String nName, string nUser, string nMail, string nPass)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "update [User] set userName='" + nUser + "',password ='"
                            + nPass + "',name= '"
                            + nName + "',mail='"
                            + nMail + "' where id=" + userID;
        ;
        cmd.ExecuteNonQuery();
        this.username = nUser;
        this.name = nName;
        this.mail = nMail;
        this.password = nPass;

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
            int subjectId = Convert.ToInt32(dataReader.GetValue(0));
            int levelId = Convert.ToInt32(dataReader.GetValue(1));
            string subjectTitle = dataReader.GetString(2);
            int classId = Convert.ToInt32(dataReader.GetValue(3));
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

            subjects[index].Item2.Add(new ClassRoom(classId, levelId));
        }

        return subjects;
    }
    static public List<ClassRoom> GetTeacherClassRooms(int teacherID)
    {
        List<ClassRoom> classes = new List<ClassRoom>();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from( Class inner join Teaches on classID=id) where Teaches.teacherID = " + teacherID.ToString();
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            classes.Add(new ClassRoom(Convert.ToInt32(dr["id"]), Convert.ToInt32(dr["levelID"])));
        }
        return classes;
    }

    static public List<Student> GetTeacherStudents(int teacherID)
    {
        List<ClassRoom> classes = GetTeacherClassRooms(teacherID);
        List<Student> students = new List<Student>();
        foreach (ClassRoom cls in classes)
        {

            students.AddRange(ClassRoom.GetAllStudentInClassRooms(cls.classRoomID));
        }
        return students;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        //   throw new Exception(""+username);
        cmd.CommandText = "insert into [User]  ([username],[password],[name],[mail],[lastSeen]"
           + ",[userType],[isAdmin],[classID])	OUTPUT INSERTED.id values ( '"
                          + username + "','"
                          + password + "','"
                          + name + "','"
                          + mail + "' , '"
                          + lastSeen.ToString()
                          + "','teacher', 0 , null)";
        userID = Convert.ToInt32(cmd.ExecuteScalar());
        cmd.Connection.Close();
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
            schedule[(int)hashTable1[startTime]][(int)hashTable2[sessionDay]] = "Class: " + dataReader.GetValue(2).ToString() +
                                                                                     "Subject: " + dataReader.GetString(3);
        }

        cmd.Connection.Close();
        return schedule;
    }
    static public List<Teacher> getAllTeachers()
    {
        List<Teacher> teachers = new List<Teacher>();
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [User] where userType = 'teacher'";
        SqlDataReader dr = cmd.ExecuteReader();
        while (dr.Read())
        {
            teachers.Add(new Teacher(Convert.ToInt32(dr["id"]), dr["userName"].ToString(), "", dr["name"].ToString(), dr["mail"].ToString(), Convert.ToDateTime(dr["lastSeen"])));
        }
        return teachers;

    }
}