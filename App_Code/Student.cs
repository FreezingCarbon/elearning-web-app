using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;


/// <summary>
/// Summary description for Student
/// </summary>
public class Student : ELearn.User
{
    public int classRoomID;
    public bool isActive;

    public Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, ClassRoom classRoom) : base(userID, username, password, name, mail, lastSeen)
    {
        if (classRoom != null)
            this.classRoomID = classRoom.classRoomID;
        else {
            this.classRoomID = -1;
            isActive = false;
        }
    }

    public Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, int classRoomID) : base(userID, username, password, name, mail, lastSeen)
    {
        this.classRoomID = classRoomID;
    }

    private Student(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, int classRoomID, bool isActive) : base(userID, username, password, name, mail, lastSeen)
    {
        this.classRoomID = classRoomID;
        this.isActive = isActive;
    }

    static public Student GetUserById(int studentId)
    {
        SqlCommand cmd = new SqlCommand();
        SqlConnection con = DatabaseConnectionFactory.GetConnection();
        cmd.Connection = con;
        cmd.CommandText = "select * from [User] where  id = " + studentId;
        SqlDataReader dataReader = cmd.ExecuteReader();
        Student student = null;
        if (dataReader.Read())
        {
            if (!dataReader.GetValue(6).ToString().Equals("student"))
                throw new Exception("the user with the specified id is not a student");

            student = new Student(Convert.ToInt32(dataReader.GetValue(0)),
                                  dataReader.GetValue(1).ToString(),
                                  dataReader.GetValue(2).ToString(),
                                  dataReader.GetValue(3).ToString(),
                                  dataReader.GetValue(4).ToString(),
                                  Convert.ToDateTime(dataReader.GetValue(5)),
                                  Convert.ToInt32(dataReader.GetValue(8)),
                                  Convert.ToBoolean(dataReader.GetValue(9)));
        }
        cmd.Connection.Close();
        return student;
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
        return ClassRoom.GetSchedule(this.classRoomID);
    }
}