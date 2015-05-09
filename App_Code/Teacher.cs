using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Teacher
/// </summary>
public class Teacher : User
{
	public Teacher()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Teacher(int userID, string username, string password, string name, string mail,
        DateTime lastSeen) : base(userID, username, password, name, mail, lastSeen)
    {

    }

    public List<Tuple<Subject, List<ClassRoom>>> getSubjects()
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

    public List<List<string>> getSchedule()
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