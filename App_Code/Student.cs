using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


/// <summary>
/// Summary description for Student
/// </summary>

using System.Data.SqlClient;public class Student : User
{
    public int classRoomID;

	public Student()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, ClassRoom classRoom) : base(userID, username, password, name, mail, lastSeen)
    {
        this.classRoomID = classRoom.classRoomID;
    }

    private Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, int classRoomID) : base(userID, username, password, name, mail, lastSeen)
    {
        this.classRoomID = classRoomID;
    }

    public ClassRoom getClass()
    {
        // static data
        Level l1 = new Level(1, "first grade");
        ClassRoom c1 = new ClassRoom(1, l1);
        return c1;
    }

    public List<List<string>> getSchedule()
    {
        SqlConnection connection = DatabaseConnectionFactory.GetConnection();
        string query = @"select Schedule.startTime, Schedule.sessionDay, Schedule.classId, Subject.title
                        from Schedule
	                        inner join Subject
	                        on Schedule.subjectId = Subject.id
                        where Schedule.classId = '" + this.classRoomID + @"'
                        order by Schedule.startTime asc";


        connection.Close();
        return null;
    }
}