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
        return null;
    }
}