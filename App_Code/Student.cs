using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Student
/// </summary>
public class Student : User
{
    public int classRoomID;

    public Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, ClassRoom classRoom) : base(userID, username, password, name, mail, lastSeen)
    {
        if (classRoom != null)
            this.classRoomID = classRoom.classRoomID;
        else this.classRoomID = -1;
    }

    private Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, int classRoomID) : base(userID, username, password, name, mail, lastSeen)
    {
        this.classRoomID = classRoomID;
    }

    static public Student GetUserById(int studentId)
    {
        // todo
        return null;
    }

    public void Insert()
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "insert into [User] values ( " 
                          + userID + " , '" 
                          + username + "','" 
                          + password + "','" 
                          + name + "','" 
                          + mail + "' , '" 
                          + lastSeen.ToString() 
                          + "','student', 0 , "
                          + ((classRoomID == -1) ? "null" : classRoomID.ToString()) + " ,0 )";
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
    }

    public ClassRoom GetClassRoom()
    {
        return ClassRoom.GetClassRoomById(classRoomID);
    }

    public override List<List<string>> GetSchedule()
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