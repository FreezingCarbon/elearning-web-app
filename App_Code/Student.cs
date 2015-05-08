using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Student
/// </summary>
public class Student : User
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
        classRoomID = classRoom.classRoomID;
    }
}