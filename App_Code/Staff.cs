using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Staff
/// </summary>
public class Staff : User
{
    public bool isAdmin;

	public Staff()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public Staff(int userID, string username, string password, string name, string mail,
        DateTime lastSeen, bool isAdmin) : base(userID, username, password, name, mail, lastSeen)
    {
        this.isAdmin = isAdmin;
    }
}