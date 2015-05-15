using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

public class Teacher : ELearn.User
{
    public Teacher(int userID, string username, string password, string name, string mail,
        DateTime lastSeen) : base(userID, username, password, name, mail, lastSeen) { }

    static public Teacher GetUserById(int teacherId)
    {
        // todo
        return null;
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
		                        from Teaches where Teaches.teacherId = '" + this.userID + @"'
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