using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Teacher : User
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

            teacher = new Teacher(Convert.ToInt32(dataReader.GetValue(0)),
                                  dataReader.GetValue(1).ToString(),
                                  dataReader.GetValue(2).ToString(),
                                  dataReader.GetValue(3).ToString(),
                                  dataReader.GetValue(4).ToString(),
                                  Convert.ToDateTime(dataReader.GetValue(5)));
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
        // static data
        Level l1 = new Level(1, "first grade");
        ClassRoom c1 = new ClassRoom(1, l1);
        ClassRoom c2 = new ClassRoom(2, l1);
        Subject s1 = new Subject(1, "english", l1);
        List<ClassRoom> subjectClasses = new List<ClassRoom>();
        subjectClasses.Add(c1);
        subjectClasses.Add(c2);
        List<Tuple<Subject, List<ClassRoom>>> classes = new List<Tuple<Subject, List<ClassRoom>>>();
        classes.Add(new Tuple<Subject, List<ClassRoom>>(s1, subjectClasses));
        return classes;
    }

    public override List<List<string>> GetSchedule()
    {
        SqlConnection connection = DatabaseConnectionFactory.GetConnection();
        string query = @"select Schedule.startTime, Schedule.sessionDay, Schedule.classId, Subject.title
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


        connection.Close();
        return null;
    }
}