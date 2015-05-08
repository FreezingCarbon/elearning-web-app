using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
}